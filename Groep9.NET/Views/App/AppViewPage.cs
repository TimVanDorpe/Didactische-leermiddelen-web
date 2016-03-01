
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Groep9.NET.Models.Domein;


/*
echt geen flauw idee waarom deze klasse er is of hoe die referenties er aan komen maar zonder
dit werkt het niet :p (jens)
    */



namespace Groep9.NET.Views.App {
    public abstract class AppViewPage<TModel> : WebViewPage<TModel> {
        protected Gebruiker CurrentUser
        {
            get
            {
                if (CurrentUser.Rol == "studenten")
                {
                    return new Student();
                }
                else return new Personeelslid();
            }
        }
    }

    public abstract class AppViewPage : AppViewPage<dynamic> {
    }
}
