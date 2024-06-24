using AutoMapper;
using Katlen.BLL.DTO;
using Katlen.BLL.Interfaces;
using Katlen.WEB.AutoMapper;
using Katlen.WEB.Extensions;
using Katlen.WEB.Models;
using Katlen.WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;

namespace Katlen.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly AutoMapperWEB autoMapper;
        private readonly ILogger<HomeController> _logger;
        private readonly ICatalog ct;
        private List<ProductCardViewModel> newProductsCards = new();
        private List<ProductCardViewModel> rateProductsCards = new();
        private const int NewProductsQuality = 6;
        private const int RateProductsQuality = 6;


        public HomeController(ILogger<HomeController> logger, ICatalog ct, IMapper mapper)
        {
            this.ct = ct;
            autoMapper = new AutoMapperWEB(mapper);
            _logger = logger;
        }

        public IActionResult Index()
        {
            HomeViewModel model = new();
            var newProducts = ct.GetAllByNew().Take(NewProductsQuality).ToList();
            autoMapper.MapProductsToProductCards(newProductsCards, newProducts);
            var rateProducts = ct.GetAllByRate().Take(RateProductsQuality).ToList();
            autoMapper.MapProductsToProductCards(rateProductsCards, rateProducts);
            model.NewProductsCards = newProductsCards;
            model.RateProductsCards = rateProductsCards;

            return View(model);
        }

        public IActionResult Search(string query)
        {
            if(query != null)
            {
                List<SearchViewModel> list = new List<SearchViewModel>();
                var products = ct.GetAll().Where(p => p.Name.Contains(query));
                foreach(var product in products)
                {
                    SearchViewModel model = new SearchViewModel()
                    {
                        Id = product.Id,
                        Name = product.Name,
                        FullPrice = product.FullPrice,
                        SalePrice = product.SalePrice,
                        Image = product.Images[0]
                    };
                    list.Add(model);
                }
                return PartialView("SearchPartial", list);
            }
            else
            {
                return PartialView("SearchPartial", null);
            }
        }

        [HttpGet]
        public IActionResult Basket()
        {
            if (HttpContext.Session.Keys.Contains("basketProducts"))
            {
                return PartialView("BasketPartial", HttpContext.Session.Get<List<BasketViewModel>>("basketProducts"));
            }
            else
            {
                return PartialView("BasketPartial", null);
            }
        }

        [HttpPost]
        public IActionResult Basket(int id, string size, int quantity)
        {
            var model = ct.GetProductById(id);

            if(model != null)
            {
                BasketViewModel item = new()
                {
                    Id = model.Id,
                    Name = model.Name,
                    FullPrice = model.FullPrice,
                    SalePrice = model.SalePrice,
                    Image = model.Images[0],
                    Quality = quantity,
                    Size = size
                };

                List<BasketViewModel> list = new();

                if (HttpContext.Session.Keys.Contains("basketProducts"))
                {
                    list = HttpContext.Session.Get<List<BasketViewModel>>("basketProducts");
                    list.Add(item);
                }
                else
                {
                    list.Add(item);
                }

                HttpContext.Session.Set("basketProducts", list);

                return PartialView("BasketPartial", list);
            }
            else
            {
                return Problem("Не удается добавить товар в корзину");
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
