using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Groep9.NET.Models.Domein;

namespace Groep9.NET.Views.App {
    public abstract class AppViewPage<TModel> : WebViewPage<TModel> {
        protected Gebruiker CurrentUser
        {
            get
            {
                return new Docent(this.User as ClaimsPrincipal);
            }
        }
    }

    public abstract class AppViewPage : AppViewPage<dynamic> {
    }
}