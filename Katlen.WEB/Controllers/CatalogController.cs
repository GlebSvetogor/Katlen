using AutoMapper;
using Katlen.BLL.DTO;
using Katlen.BLL.Interfaces;
using Katlen.DAL.EF;
using Katlen.DAL.Entities;
using Katlen.WEB.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.IO;
using Microsoft.AspNetCore.Mvc.Routing;
using Katlen.WEB.AutoMapper;
using Katlen.WEB.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Authorization;

namespace Katlen.WEB.Controllers
{
    public class CatalogController : Controller
    {
        private readonly AutoMapperWEB autoMapper;
        private readonly ICatalog ct;
        private readonly int pageSize = 4;
        private List<ProductCardViewModel> productsCards = new();

        public CatalogController(ICatalog ct, IMapper mapper)
        {
            this.ct = ct;
            autoMapper = new AutoMapperWEB(mapper);
        }

        public IActionResult Index(int page = 1)
        {
            if (HttpContext.Session.Keys.Contains("productsCards"))
            {
                IndexViewModel viewModel = GetIndexViewModel(page);
                return View(viewModel);
            }
            else
            {
                var products = ct.GetAll();

                autoMapper.MapProductsToProductCards(productsCards, products);

                HttpContext.Session.Set("productsCards", productsCards);

                IndexViewModel viewModel = GetIndexViewModel();
                return View(viewModel);
            }
        }

        [HttpGet]
        public IActionResult Filtr(string[] names=null, int priceFrom=0, int priceTo=0, string[] sizes = null, string[] materials=null, string[] seasons=null)
        {
            var products = ct.MakeFiltr(names, priceFrom, priceTo, sizes, materials, seasons);
            
            autoMapper.MapProductsToProductCards(productsCards, products);
            HttpContext.Session.Set("productsCards", productsCards);

            IndexViewModel viewModel = GetIndexViewModel();

            return View("Index", viewModel);
        }

        [HttpGet]
        public IActionResult GetSortSelectedValue(string value)
        {
            List<ProductCardViewModel> productsCards = HttpContext.Session.Get<List<ProductCardViewModel>>("productsCards");
            IEnumerable<ProductCardViewModel> sortedList = new List<ProductCardViewModel>();

            switch (value)
            {
                case "priceSort":
                    sortedList = from pc in productsCards
                                    orderby pc.SalePrice
                                    select pc;
                    break;
                case "sizeSort":
                    sortedList = from pc in productsCards 
                                    orderby pc.MinimumAvailableSize
                                    where pc.MinimumAvailableSize != -1
                                    select pc;
                    break;
                case "mixedSort":
                    Random rng = new Random();
                    sortedList = productsCards.OrderBy(pr => rng.Next());
                    break;
                default:
                    return BadRequest("Value is required");
            }
            
            HttpContext.Session.Set("productsCards", sortedList.ToList());

            IndexViewModel viewModel = GetIndexViewModel();
            return View("Index", viewModel);
        }

        [HttpGet]
        public IActionResult GetOptionSelectedValue(string value)
        {
            switch (value)
            {
                case "allProducts":
                    HttpContext.Session.Clear();
                    return RedirectToAction("Index");
                case "newProducts":
                    var products = ct.GetAllByNew();
                    autoMapper.MapProductsToProductCards(productsCards, products);
                    HttpContext.Session.Set("productsCards", productsCards);
                    break;
                case "bestProducts":
                    products = ct.GetAllByRate();
                    autoMapper.MapProductsToProductCards(productsCards, products);
                    HttpContext.Session.Set("productsCards", productsCards);
                    break;
                default:
                    return BadRequest("Value is required");
            }

            IndexViewModel viewModel = GetIndexViewModel();
            return View("Index", viewModel);
        }
        public IndexViewModel GetIndexViewModel(int page = 1)
        {
            List<ProductCardViewModel> productsCards = HttpContext.Session.Get<List<ProductCardViewModel>>("productsCards");
            
            var count = productsCards.Count();
            var items = productsCards.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                PageProductsCards = items,
                ProductsCardsQuality = productsCards.Count,
                Filtrs = HttpContext.Session.Get<Dictionary<string, string[]>>("filtrs")
            };

            return viewModel;
        }

    }


    
}
