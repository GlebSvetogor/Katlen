using Katlen.DAL.EF;
using Katlen.DAL.Entities;
using Katlen.WEB.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Katlen.WEB.Controllers
{
    public class AccountController : Controller
    {
        private KatlenContext db;
        public AccountController(KatlenContext db)
        {
            this.db = db;
        }

        public IActionResult Register()
        {
            return PartialView("_RegisterPartial", new RegisterModel());
        }

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Здесь можно добавить логику для регистрации пользователя.
                // Например, добавить пользователя в базу данных.

                return Json(new { success = true });
            }

            return PartialView("_RegisterPartial", model);
        }

        public IActionResult Login()
        {
            return PartialView("_LoginPartial", new LoginModel());
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {

                return Json(new { success = true });
            }
            return PartialView("_LoginPartial", model);
        }
        
    }
}
