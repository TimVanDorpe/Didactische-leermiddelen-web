using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Groep9.NET.Infrastructure;
using Groep9.NET.Models.DAL;
using Groep9.NET.Models.Domein;

namespace Groep9.NET
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ModelBinders.Binders.Add(typeof(Gebruiker), new GebruikerModelBinder());
            //ApplicationDbContext db = new ApplicationDbContext();
            //db.Database.Initialize(true);
        }
    }
}
