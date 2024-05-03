using Katlen.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Katlen.WEB.Controllers
{
    public class CardProductController : Controller
    {
        private readonly ICardProduct cp;
        public CardProductController(ICardProduct cp) 
        {
            this.cp = cp;
        }
        // GET: CardProductController
        public ActionResult Index(int id)
        {
            var cardProduct = cp.GetCardProductById(id);
            if(cardProduct is not null)
            {
                return View(cardProduct);
            }
            return RedirectToAction("Error");
        }

    }
}
