using AutoMapper;
using Katlen.BLL.DTO;
using Katlen.BLL.Interfaces;
using Katlen.WEB.AutoMapper;
using Katlen.WEB.Models;
using Katlen.WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;
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

            //return View(model);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
