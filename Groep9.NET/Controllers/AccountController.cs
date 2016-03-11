using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Groep9.NET.ViewModels;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Text;
using Groep9.NET.Models.Domein;

namespace Groep9.NET.Controllers {
    [AllowAnonymous]
    public class AccountController : Controller {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController() {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager) {
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

        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl) {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LogInViewModel model, string returnUrl) {
            if (!ModelState.IsValid) {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Wachtwoord, model.RememberMe, shouldLockout: false);//hiervoor aparte service maken, die dan enkel
            //signinasinc nog doorgeeft
            switch (result) {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View(model);
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("Index", "Home");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Foutief e-mail / wachtwoord.");
                    return View(model);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl) {
            if (Url.IsLocalUrl(returnUrl)) {
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



        //public async Task RunAsyncLoginRestAPi(LogInViewModel model)
        //{

        //    using (var client = new HttpClient())
        //    {
        //        //pw hashen
        //        System.Security.Cryptography.SHA256Managed crypt = new System.Security.Cryptography.SHA256Managed();
        //        System.Text.StringBuilder hash = new System.Text.StringBuilder();
        //        byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(model.Wachtwoord), 0, Encoding.UTF8.GetByteCount(model.Wachtwoord));
        //        foreach (byte theByte in crypto)
        //        {
        //            hash.Append(theByte.ToString("x2"));
        //        }

        //        string hashedpw = hash.ToString();

        //        client.BaseAddress = new Uri("https://studservice.hogent.be/auth/" + model.Studentnummer + " / " + hashedpw);
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        JSONObject jsonobject = Newtonsoft.Json.JsonConvert.DeserializeObject<JSONOBject>(jsonstring);


        //    }
        //}


    }
}