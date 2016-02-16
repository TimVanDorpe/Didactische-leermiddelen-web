using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Groep9.NET.Models.Domein;
using Groep9.NET.ViewModels;
using Groep9.NET.Models.DAL;

namespace Groep9.NET.Controllers
{
    public class CatalogusController : Controller
    {
        // GET: Catalogus

        private IProductRepository productRepository;
        private Context context;

        public CatalogusController(IProductRepository pr)
        {
            productRepository = pr;
        }

       /* [HttpGet]
        public ActionResult Index(string zoekenNaar , string trefwoord ="")
        {
            IEnumerable<Product> producten;
            producten = productRepository.VindAlleProducten().OrderBy(p => p.Naam).ToList();
            if (zoekenNaar == "Omschrijving")
            {
                return View(context.Producten.Where(x => x.Omschrijving == trefwoord || trefwoord == null).ToList());

            }
            if (zoekenNaar == "Naam")
            {
                return View(context.Producten.Where(x => x.Naam == trefwoord || trefwoord == null).ToList());
            }
            if (Request.IsAjaxRequest())
                return PartialView("Producten", producten);
            ViewBag.Trefwoord = trefwoord;
            return View(producten);

        }*/
       

        public ActionResult Index(string zoekenNaar, string trefwoord = "")
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

                        if (zoekenNaar == "Omschrijving")
                        {
                            producten = productRepository.VindAlleProducten()
                                   .Where(p => p.Omschrijving.Equals(trefwoord))
                                   .OrderBy(g => g.Naam);
                            //producten = context.Producten.Where(x => x.Omschrijving == trefwoord || trefwoord == null).ToList();

                        }
                        if (zoekenNaar == "Naam")
                        {
                            producten = productRepository.VindAlleProducten()
                                    .Where(p => p.Naam.Equals(trefwoord))
                                    .OrderBy(g => g.Naam);
                        }
                        else { 
                        //zoeken
                        producten =
                                productRepository.VindAlleProducten()
                                    .Where(p => p.Naam.Equals(trefwoord))
                                    .OrderBy(g => g.Naam);}

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