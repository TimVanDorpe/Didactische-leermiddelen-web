﻿using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Groep9.NET.ViewModels;

namespace Groep9.NET.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller {
        public ActionResult LogIn() {
            return View();
        }

        [HttpGet]
        public ActionResult LogIn(string returnUrl) {
            var model = new LogInViewModel {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult LogIn(LogInViewModel model) {
            if (!ModelState.IsValid) {
                return View();
            }

            // tijdelijke authenticatie, moet hier mee ingelogd worden of het is fout
            if (model.Email == "user@user.com" && model.Password == "password") {
                var identity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, "Jens"),
                new Claim(ClaimTypes.Email, "a@b.com"),
                new Claim(ClaimTypes.Country, "Belgium")
            },
                    "ApplicationCookie");

                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;

                authManager.SignIn(identity);

                return Redirect(GetRedirectUrl(model.ReturnUrl));
            }

            // user authN failed
            ModelState.AddModelError("", "Invalid email or password");
            return View();
        }

        // na inloggen wordt er doorverwezen naar de catalogus pagina //ofcourse
        private string GetRedirectUrl(string returnUrl) {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl)) {
                return Url.Action("index", "Catalogus");
            }

            return returnUrl;
        }

        public ActionResult LogOut() {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("index", "home");
        }


    }
}