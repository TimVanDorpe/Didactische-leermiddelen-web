using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Groep9.NET.Models.Domein;
using Groep9.NET.ViewModels;

namespace Groep9.NET.Controllers
{
    public class CatalogusController : Controller
    {
        // GET: Catalogus

        private IProductRepository productRepository;

        public CatalogusController(IProductRepository pr)
        {
            productRepository = pr;
        }
        
        public ActionResult Index()
        {
            IEnumerable<Product> producten = productRepository.VindAlleProducten().OrderBy(p => p.Naam);
            IEnumerable<ProductViewModel> productViewModels =
                producten.Select(p => new ProductViewModel(p)).ToList();
            return View(productViewModels);
        }   
    }
}