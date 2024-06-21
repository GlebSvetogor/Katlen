using Katlen.DAL.EF;
using Katlen.DAL.Entities;
using Katlen.WEB.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
        public async Task<IActionResult> Index()
        {
            var user = HttpContext.User;

            if (user.Identity.IsAuthenticated)
            {
                string userName = user.Identity.Name;

                return View();
            }

            return Content("Unuotorized user");
        }

        public IActionResult Register()
        {
            return PartialView("_RegisterPartial", new RegisterModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                await db.Users.AddAsync(new DAL.Entities.User() { Email = model.Email, Name = model.Name, Password = model.Password, Phone = model.Phone == null ? "" : model.Phone});
                await db.SaveChangesAsync();

                /*return PartialView("_SuccessRegister", model);*/
                return Json(new { success = true });
            }

            return PartialView("_RegisterPartial", model);
        }

        public IActionResult Login()
        {
            return PartialView("_LoginPartial", new LoginModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (user is null)
                {
                    ModelState.AddModelError(string.Empty, "Пользователь с таким Email и паролем не найден.");
                    return PartialView("_LoginPartial", model);
                }

                var claims = new List<Claim>() { new Claim(ClaimTypes.Name, model.Email) };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookie");

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return Json(new { success = true, redirectUrl = Url.Action("Index", "Account") });
            }
            return PartialView("_LoginPartial", model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
        
    }
}
