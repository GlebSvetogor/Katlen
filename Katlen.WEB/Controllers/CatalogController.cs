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

namespace Katlen.WEB.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICatalog ct;
        private readonly int pageSize = 3;

        public CatalogController(ICatalog ct, IMapper mapper)
        {
            this.ct = ct;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            List<ProductCardViewModel> productsCards = new List<ProductCardViewModel>();
            var products = ct.GetAll();

            MapFromProductsDTOToProductsCards(productsCards, products);

            HttpContext.Session.Set<List<ProductCardViewModel>>("productsCards", productsCards);

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

            MapFromProductsDTOToProductsCards(productsCards, products);

            HttpContext.Session.Set<List<ProductCardViewModel>>("productsCards", productsCards);
            HttpContext.Session.Set<Dictionary<string, string[]>>("filtrs", filtrs);

            IndexViewModel viewModel = GetIndexViewModel();

            return View("Index", viewModel);
        }

        public IActionResult IndexDefault(int page)
        {
            IndexViewModel viewModel = GetIndexViewModel(page);

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

        public int CountProductSale(int salePrice, int fullPrice)
        {
            int salePercent = (int)(100 - (salePrice * 100 / fullPrice));
            return salePercent;
        }
        public void MapFromProductsDTOToProductsCards(List<ProductCardViewModel> productsCards, IEnumerable<ProductDTO> products)
        {
            foreach (var product in products)
            {
                ProductCardViewModel productCard = _mapper.Map<ProductCardViewModel>(product);
                productCard.Image = product.Images[0];
                productCard.SalePercent = CountProductSale(productCard.SalePrice, productCard.FullPrice);

                productsCards.Add(productCard);
            }
        }
    }

    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, System.Text.Json.JsonSerializer.Serialize(value));
        }

        public static T? Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : System.Text.Json.JsonSerializer.Deserialize<T>(value);
        }
    }
}
