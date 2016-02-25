using System.Web.Mvc;
using Groep9.NET.Models.Domein;

namespace Groep9.NET.Infrastructure {
    public class GebruikerModelBinder : IModelBinder {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {

            if (controllerContext.HttpContext.User.Identity.IsAuthenticated) {
                IGebruikerRepository repos = (IGebruikerRepository)DependencyResolver.Current.GetService(typeof(IGebruikerRepository));
                // return repos.FindBy("1000000000"); 
                Gebruiker gebruiker = repos.FindByEmail(controllerContext.HttpContext.User.Identity.Name);
                repos.Add(gebruiker);
                repos.SaveChanges();
                return repos.FindByEmail(controllerContext.HttpContext.User.Identity.Name);
            }
            return null;
        }
    }
}
