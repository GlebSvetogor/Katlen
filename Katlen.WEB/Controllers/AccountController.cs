using Katlen.DAL.EF;
using Katlen.DAL.Entities;
using Katlen.WEB.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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

        // Метод для отображения формы регистрации
        public IActionResult Register()
        {
            return PartialView("_RegisterPartial", new RegisterModel());
        }

        // Метод для обработки данных формы регистрации
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

    }
}
