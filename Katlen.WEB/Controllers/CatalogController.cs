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

namespace Katlen.WEB.Controllers
{
    public class CatalogController : Controller
    {
        private readonly AutoMapperWEB autoMapper;
        private readonly ICatalog ct;
        private readonly int pageSize = 4;

        public CatalogController(ICatalog ct, IMapper mapper)
        {
            this.ct = ct;
            autoMapper = new AutoMapperWEB(mapper);
        }

        public IActionResult Index()
        {
            List<ProductCardViewModel> productsCards = new List<ProductCardViewModel>();
            var products = ct.GetAll();

            autoMapper.MapProductsToProductCards(productsCards, products);

            HttpContext.Session.Set("productsCards", productsCards);

            IndexViewModel viewModel = GetIndexViewModel();
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Filtr(string[] names=null, int priceFrom=0, int priceTo=0, string[] sizes = null, string[] materials=null)
        {
            List<ProductCardViewModel> productsCards = new List<ProductCardViewModel>();
            List<ProductDTO> products = new List<ProductDTO>();
            Dictionary<string, string[]> filtrs = new Dictionary<string, string[]>();

            if (names != null)
            {
                products = ct.GetAllByNames(names);
                filtrs.Add("Одежда", names);
            }

            if(priceFrom != priceTo)
            {
                if(products.IsNullOrEmpty())
                {
                    products = ct.GetAllByPrice(priceFrom, priceTo);
                }
                else
                {
                    var filtrProducts = ct.GetAllByPrice(priceFrom, priceTo);
                    products.RemoveAll(product => !filtrProducts.Any(fp => fp.Id == product.Id)); 
                }
                filtrs.Add("Цена", new string[] {priceFrom.ToString(), priceTo.ToString()});
            }

            if (sizes != null)
            {
                if (products.IsNullOrEmpty())
                {
                    products = ct.GetAllBySizes(sizes);
                }
                else
                {
                    var filtrProducts = ct.GetAllBySizes(sizes);
                    products.RemoveAll(product => !filtrProducts.Any(fp => fp.Id == product.Id));
                }
                filtrs.Add("Размеры", sizes);

            }

            if (materials != null)
            {
                if (products.IsNullOrEmpty())
                {
                    products = ct.GetAllByMaterials(materials);
                }
                else
                {
                    var filtrProducts = ct.GetAllByMaterials(materials);
                    products.RemoveAll(product => !filtrProducts.Any(fp => fp.Id == product.Id));
                }
                filtrs.Add("Материалы", materials);
            }

            autoMapper.MapProductsToProductCards(productsCards, products);

            HttpContext.Session.Set("productsCards", productsCards);
            HttpContext.Session.Set("filtrs", filtrs);

            IndexViewModel viewModel = GetIndexViewModel();

            return View("Index", viewModel);
        }

        public IActionResult IndexDefault(int page)
        {
            IndexViewModel viewModel = GetIndexViewModel(page);
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
        public IActionResult GetSeasonSelectedValue(string value)
        {
            List<ProductCardViewModel> productsCards = HttpContext.Session.Get<List<ProductCardViewModel>>("productsCards");
            IEnumerable<ProductCardViewModel> sortedList = new List<ProductCardViewModel>();

            if(value == "allSeasons") return RedirectToAction("Index");

            sortedList = from pc in productsCards
                            where pc.Seasons.Contains(value)
                            select pc;

            HttpContext.Session.Set("productsCards", sortedList.ToList());

            IndexViewModel viewModel = GetIndexViewModel();
            return View("Index", viewModel);
        }

        [HttpGet]
        public IActionResult GetOptionSelectedValue(string value)
        {
            List<ProductCardViewModel> productsCards = new List<ProductCardViewModel>();
            var products = ct.GetAll();
            autoMapper.MapProductsToProductCards(productsCards, products);

            switch (value)
            {
                case "allProducts":
                    HttpContext.Session.Set("productsCards", productsCards);
                    break;
                case "newProducts":
                    productsCards = productsCards.AsEnumerable().Reverse().ToList();
                    HttpContext.Session.Set("productsCards", productsCards);
                    break;
                case "bestProducts":
                    var sortedList = from pc in productsCards
                                    orderby pc.Rate
                                    select pc;
                    HttpContext.Session.Set("productsCards", sortedList.AsEnumerable().Reverse().ToList());
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
