using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Groep9.NET.Models.Domein;
using Groep9.NET.ViewModels;
using Groep9.NET.Models.DAL;
using System.Globalization;
using System.Data.Entity;

namespace Groep9.NET.Controllers
{
    // gebruikers kunnen enkel nog op de catalogus na inloggen als user@user.com / password
    public class CatalogusController : Controller
    {
        // GET: Catalogus

        private IProductRepository productRepository;
        private IDoelgroepRepository doelgroepRepository;
        private ILeergebiedRepository leergebiedRepository;
        //private IGebruikerRepository gebruikerRepository;

        public CatalogusController(IProductRepository pr, IDoelgroepRepository dr, ILeergebiedRepository lr)
        {
            productRepository = pr;
            doelgroepRepository = dr;
            leergebiedRepository = lr;
          //  gebruikerRepository = gr;
            
        }
    
        public ActionResult Index( string trefwoord = "", string doelgroep = "", string leergebied = "" )
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
                   //producten = producten.Where(p=> p.Doelgroepen.ElementAt(1).Naam.Equals(doelgroep));
                        //    var productdoelgroepen 
                        //producten = producten.Select
                       
                        }
                        if (!leergebied.Equals(""))
                        {
                        producten = producten.Where(p => p.Leergebieden.ElementAt(1).Naam.Equals(leergebied));
                    }



            
                        FillDropDownList();
           





            if (Request.IsAjaxRequest())
                        return PartialView("Producten", producten);
                    
                    

                    return View(producten);
               
                
                      
            return RedirectToAction("Index", "Home");
        }
      

        private SelectList GetDoelgroepSelectList()
        {
                                 
                     
         //   return new SelectList(productRepository.VindAlleProducten().Include(p => p.Doelgroepen.Select(g => g.Naam)).ToList());
            return new SelectList(doelgroepRepository.VindAlleDoelgroepen().Select(p=>p.Naam));

        }
        private SelectList GetLeergebiedSelectList()
        {
            return new SelectList(leergebiedRepository.VindAlleLeergebieden().Select(p=>p.Naam));
           // return new SelectList(productRepository.VindAlleProducten().Include(p => p.Leergebieden.Select(g => g.Naam)).ToList());


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

        public ActionResult AddToVerlanglijst(int productId)
        {

            return RedirectToAction("Index");
        }
    }
}