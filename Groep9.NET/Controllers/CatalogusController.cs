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
             if (ModelState.IsValid)
                {
                    try
                    {
                        IEnumerable<Product> producten = productRepository.VindAlleProducten().OrderBy(p => p.Naam);
                      
                        return View(producten);
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", ex.Message);
                    }
                }
                      
            return RedirectToAction("Index", "Home");
        }   


        public ActionResult Details(int id)
        {
            Product product = productRepository.FindByProductNummer(id);
            return View(product);
        }
    }
}