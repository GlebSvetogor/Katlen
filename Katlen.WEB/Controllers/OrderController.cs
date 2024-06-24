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

            return View();
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
