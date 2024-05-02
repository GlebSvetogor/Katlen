using Katlen.WEB.Models;
using Katlen.WEB.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Katlen.WEB.Controllers
{
    public class AccountController : Controller
    {
        public AccountController()
        {
           
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        
    }
}
