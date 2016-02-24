using Groep9.NET.Models.Domein;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Groep9.NET.Controllers
{
    // gebruikers kunnen enkel nog op de catalogus na inloggen als user@user.com / password
    public class CatalogusController : Controller
    {
        // GET: Catalogus

        private IProductRepository productRepository;
        //private IGebruikerRepository gebruikerRepository;
        private Gebruiker gebruiker;

        public CatalogusController(IProductRepository pr)
        {
            productRepository = pr;
            //  gebruikerRepository = gr;
            //gebruiker = currentuser;
        }
    
        public ActionResult Index( string trefwoord = "", string doelgroep = "", string leergebied = "" , int productverlanglijstID = 0)
        {
            
            
                    
                    if (doelgroep.Equals("-- Selecteer doelgroep --"))
                        {
                            doelgroep = "";
                        }
                    if (leergebied.Equals("-- Selecteer doelgroep --"))
                    {
                        leergebied = "";
                    }
            IEnumerable<Product> producten = productRepository.VindAlleProducten().ToList();



                    if (!trefwoord.Equals(""))
                    {              
                        producten =
                            producten.Where(p => p.Naam.ToLower().Contains(trefwoord.ToLower()) || p.Omschrijving.ToLower().Contains(trefwoord.ToLower()));
                            }
            

            if (!doelgroep.Equals(""))
                        {
                        //producten = producten.Where(p=> p.Doelgroep.Naam.Equals(doelgroep));
                        }
                        if (!leergebied.Equals(""))
                        {
                       // producten = producten.Where(p => p.Leergebied.Naam.Equals(leergebied));
                    }


            if (productverlanglijstID != 0)
                AddToVerlanglijst(productverlanglijstID);
            FillDropDownList();
           
            if (Request.IsAjaxRequest())
                        return PartialView("Producten", producten);
                    return View(producten);
                            
                      
            return RedirectToAction("Index", "Home");
        }


      

        private SelectList GetDoelgroepSelectList()
        {
            return new SelectList(productRepository.VindAlleProducten().Select(s => s.Doelgroepen.Select(p => p.Naam).Distinct()));
        }
        private SelectList GetLeergebiedSelectList()
        {
            return new SelectList(productRepository.VindAlleProducten().Select(s => s.Doelgroepen.Select(p => p.Naam).Distinct()));


        }
        public ActionResult Details(int id)
        {
            Product product = productRepository.FindByProductNummer(id);
            return View(product);
        }

        public void FillDropDownList()
        {
         
            ViewBag.leergebied = GetLeergebiedSelectList();
            ViewBag.doelgroep = GetDoelgroepSelectList();

        }

        public void AddToVerlanglijst(int productId)
        {
            gebruiker.VoegProductAanVerlanglijstToe(productRepository.FindByProductNummer(productId));
            
        }

        public ActionResult Verlanglijst()
        {
            IEnumerable<Product> producten = gebruiker.VerlangLijst.ToList();
            return View(producten);
        }
    }
}