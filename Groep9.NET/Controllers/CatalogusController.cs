using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Groep9.NET.Models.Domein;
using Groep9.NET.ViewModels;
using Groep9.NET.Models.DAL;

namespace Groep9.NET.Controllers
{
    // gebruikers kunnen enkel nog op de catalogus na inloggen als user@user.com / password
    public class CatalogusController : AppController
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
       

        public ActionResult Index(/*string zoekenNaar,*/ string trefwoord = "", int doelgroep = 0, int leergebied = 0)
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

                        /* if (zoekenNaar == "Omschrijving")
                         {
                             producten = productRepository.VindAlleProducten()
                                    .Where(p => p.Omschrijving.Contains(trefwoord))
                                    .OrderBy(g => g.Naam);
                             //producten = context.Producten.Where(x => x.Omschrijving == trefwoord || trefwoord == null).ToList();

                         }
                         if (zoekenNaar == "Naam")
                         {
                             producten = productRepository.VindAlleProducten()
                                     .Where(p => p.Naam.Contains(trefwoord))
                                     .OrderBy(g => g.Naam);
                         }
                         else { */
                        //zoeken
                        producten =
                                productRepository.VindAlleProducten()
                                    .Where(p => p.Naam.Contains(trefwoord) || p.Omschrijving.Contains(trefwoord))
                                    .OrderBy(g => g.Naam);
                    }

                        
                   if (Request.IsAjaxRequest())
                        return PartialView("Producten", producten);
                    ViewBag.Doelgroepen = GetDoelgroepSelectList(doelgroep);
                    ViewBag.Leergebieden = GetLeergebiedSelectList(leergebied);
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

        private SelectList GetDoelgroepSelectList(int selectedValue = 0)
        {
            return new SelectList(productRepository.VindAlleProducten().GroupBy(g=>g.Doelgroep),
                "Doelgroep", "Doelgroep", selectedValue);
        }
        private SelectList GetLeergebiedSelectList(int selectedValue = 0)
        {
            return new SelectList(productRepository.VindAlleProducten().GroupBy(g => g.Leergebied),
                "Leergebied", "Leergebied", selectedValue);
        }

        public ActionResult Details(int id)
        {
            Product product = productRepository.FindByProductNummer(id);
            return View(product);
        }
    }
}