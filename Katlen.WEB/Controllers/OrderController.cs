using Katlen.WEB.Extensions;
using Katlen.WEB.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Katlen.WEB.Controllers
{
    public class OrderController : Controller
    {
        /*[Authorize]*/
        public ActionResult Index()
        {
            var basket = HttpContext.Session.Get<List<BasketViewModel>>("basketProducts");
            if(basket != null && basket.Count > 0)
            {
                int totalFullPrice = 0, totalPrice = 0, totalSale = 0;

                foreach(var pr in basket)
                {
                    totalFullPrice += pr.Quality * pr.FullPrice;
                    totalPrice += pr.Quality * pr.SalePrice;
                }

                totalSale = totalFullPrice -  totalPrice;

                OrderViewModel orderViewModel = new OrderViewModel()
                {
                    TotalFullPrice = totalFullPrice,
                    TotalSale = totalSale,
                    TotalPrice = totalPrice,
                    Basket = basket
                };

                return View(orderViewModel);
            }
            else
            {
                return Problem("Нужно добавить хотя бы один товар в коризну");
            }

        }

        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult Gratitude()
        {
            return View();
        }

    }
}
