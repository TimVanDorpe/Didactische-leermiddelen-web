using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Groep9.NET.ViewModels;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Groep9.NET.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //public ActionResult LogIn() {
        //    return View();
        //}

        //[HttpGet]
        //public ActionResult LogIn(string returnUrl) {
        //    var model = new LogInViewModel {
        //        ReturnUrl = returnUrl
        //    };

        //    if (HttpContext.Request.IsAuthenticated)
        //    {
        //        //return RedirectToAction("index", "home");
        //        return RedirectToAction("ReedsIngelogd", "Account");
        //    }
        //    else
        //    {
        //        return View(model);

        //    }
        //}

        //public ActionResult ReedsIngelogd()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult LogIn(LogInViewModel model) {
        //    if (!ModelState.IsValid) {
        //        return View();
        //    }

        //    // tijdelijke authenticatie, moet hier mee ingelogd worden of het is fout
        //    if (model.Email == "user@user.com" && model.Wachtwoord == "password") {
        //        var identity = new ClaimsIdentity(new[] {
        //        new Claim(ClaimTypes.Name, "Voorlopige Gebruiker"),
        //        new Claim(ClaimTypes.Email, "a@b.com"),
        //        new Claim(ClaimTypes.Country, "Belgium")
        //    },
        //            "ApplicationCookie");

        //        var ctx = Request.GetOwinContext();
        //        var authManager = ctx.Authentication;

        //        authManager.SignIn(identity);

        //        return Redirect(GetRedirectUrl(model.ReturnUrl));
        //    }

        //    // user authN failed
        //    ModelState.AddModelError("", "Foute e-mail of paswoord ingevoerd");
        //    return View();
        //}
        // GET: /Account/Login
        ////[AllowAnonymous]
        //public ActionResult Login(string returnUrl)
        //{
        //    ViewBag.ReturnUrl = returnUrl;
        //    return View();
        //}


        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LogInViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Wachtwoord, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View(model);
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("Index", "Home");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
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
            return RedirectToAction("Login");
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
    }
}