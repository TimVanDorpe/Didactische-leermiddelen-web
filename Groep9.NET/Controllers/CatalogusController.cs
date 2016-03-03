﻿using Groep9.NET.Models.DAL;
using Groep9.NET.Models.Domein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Groep9.NET.Controllers
{
    [Authorize]
    public class CatalogusController : Controller
    {
        // GET: Catalogus

        private IProductRepository productRepository;
        private IDoelgroepRepository doelgroepRepository;
        private ILeergebiedRepository leergebiedRepository;
        private IGebruikerRepository gebruikerRepository;
      //  private ApplicationDbContext adc;
       

        public CatalogusController(IProductRepository pr, IDoelgroepRepository dr, ILeergebiedRepository lr, IGebruikerRepository gr)
        {
            productRepository = pr;
            doelgroepRepository = dr;
            leergebiedRepository = lr;
           gebruikerRepository = gr;
            
        }
    
        public ActionResult Index( Gebruiker gebruiker, string trefwoord = "", string doelgroep = "", string leergebied = "")
        {
            //if (prodId >= 0)
            //{
            //    AddToVerlanglijst(prodId, gebruikerRepository.FindByEmail(User.Identity.Name));
            //}
          
                    if (doelgroep.Equals("-- Selecteer doelgroep --"))
                        {
                            doelgroep = "";
                        }
                    if (leergebied.Equals("-- Selecteer leergebied --"))
                    {
                        leergebied = "";
                    }
                     IEnumerable<Product> producten = productRepository.VindAlleProducten().ToList();
            if (!trefwoord.Equals(""))
            {
                producten =
                    producten.Where(
                        p =>
                            p.Naam.ToLower().Contains(trefwoord.ToLower()) ||
                            p.Omschrijving.ToLower().Contains(trefwoord.ToLower()));
            }
            if (gebruiker.Rol.Equals("Student")) {
                    producten = producten.Where(p => p.Uitleenbaarheid);

                }

            
            



            FillDropDownList();

            if (Request.IsAjaxRequest())
                        return PartialView("Producten", producten);
                    
                    

                    return View(producten);
               
                
                      
           // return RedirectToAction("Index", "Home");
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
        public ActionResult Verlanglijst(Gebruiker gebruiker)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("login", "Account");
            }

            //string email = gebruiker.Email;
            // Gebruiker currentUser =  gebruikerRepository.FindByEmail(User.Identity.Name);
            IList<Product> verlanglijst = gebruiker.VerlangLijst.ToList();
            return View(verlanglijst);
        }

        public ActionResult AddToVerlanglijst(int id, Gebruiker gebruiker)
        {
            // Gebruiker currentUser = gebruikerRepository.FindByEmail(User.Identity.Name);
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("login", "Account");
            }
           
                Product product = productRepository.FindByProductNummer(id);
                gebruiker.VoegProductAanVerlanglijstToe(product);
            gebruikerRepository.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult RemoveFromVerlanglijst(int id, Gebruiker gebruiker)
        {
            // Gebruiker currentUser = gebruikerRepository.FindByEmail(User.Identity.Name);
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("login", "Account");
            }

            Product product = productRepository.FindByProductNummer(id);
            gebruiker.verwijderProductUitVerlanglijst(product);
            gebruikerRepository.SaveChanges();
            IList<Product> verlanglijst = gebruiker.VerlangLijst.ToList();
            return RedirectToAction("Verlanglijst");
        }
        public ActionResult AddOfVerwijderVerlanglijst(int id, string actie, Gebruiker gebruiker)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("login", "Account");
            }
            if (actie.Equals("toevoegen"))
            {
                Product product = productRepository.FindByProductNummer(id);
                gebruiker.VoegProductAanVerlanglijstToe(product);
                gebruikerRepository.SaveChanges();

            }
            else
            {
                Product product = productRepository.FindByProductNummer(id);
                gebruiker.verwijderProductUitVerlanglijst(product);
                gebruikerRepository.SaveChanges();
            }
            // Gebruiker currentUser = gebruikerRepository.FindByEmail(User.Identity.Name);
            

           
            return RedirectToAction("Index");
        }
        

        //methode voor reserveerknop, die aantal meegeeft aan methode product.Reserveer
        public ActionResult Reservatie(Gebruiker gebruiker, int aantal = 0,int productnummer = 0)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("login", "Account");
            }
            Product product= productRepository.FindByProductNummer(productnummer);
            productRepository.ReserveerProduct(productnummer, aantal);
           
            
            DateTime start = productRepository.BerekenStartDatumReservatieWeek();
            DateTime end = productRepository.BerekenEindDatumReservatieWeek();
            gebruikerRepository.ReserveerProduct(product, start, end,aantal, gebruiker);
            //Reservatie Niew = new Reservatie(Product product, start, end, aantal);
            //IList<Product> verlanglijst = gebruiker.VerlangLijst.ToList();
            //Reservatie x = new Reservatie(verlanglijst.Last(), start, end, aantal);
            return RedirectToAction("Verlanglijst");
        }

        //methode voor reserveerknop, die aantal meegeeft aan methode product.Reserveer
    }
}