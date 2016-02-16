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
        
        public ActionResult Index(string trefwoord = "")
        {
             if (ModelState.IsValid)
                {
                    try
                    {
                        IEnumerable<Product> producten;
                        if (trefwoord.Equals(""))
                        {
                            producten = productRepository.VindAlleProducten().OrderBy(p => p.Naam).ToList();
                        }
                        else
                        {
                        //zoeken
                            producten =
                                productRepository.VindAlleProducten()
                                    .Where(p => p.Naam.Equals(trefwoord))
                                    .OrderBy(g => g.Naam);

                        }
                    if (Request.IsAjaxRequest())
                        return PartialView("Producten", producten);
                    ViewBag.Trefwoord = trefwoord;
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