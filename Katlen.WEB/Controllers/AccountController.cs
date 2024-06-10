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
        [Authorize]
        public IActionResult Index()
        {
            return Content(User.Identity.Name);
        }
        //[HttpGet]
        //public IActionResult Register() 
        //{
        //    return PartialView("_Register", new RegisterModel());
        //}
        
        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                return PartialView("_SuccessMessage", model);
            }
            else
            {
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                return PartialView("_Register", model);
            }
            //if (ModelState.IsValid)
            //{
            //    User user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
            //    if (user == null)
            //    {
            //        db.Users.Add(new DAL.Entities.User { Phone = model.Phone, Name = model.Name, Email = model.Email, Password = model.Password });
            //        await db.SaveChangesAsync();

            //        await Authenticate(model.Email);

            //        return RedirectToAction("Index", "Home");
            //    }
            //    else
            //        ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            //}
        }

        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookid", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if(user != null)
                {
                    await Authenticate(model.Email);

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и (или) пароль");
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
