﻿using Groep9.NET.Models.Domein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Groep9.NET.ViewModels;

namespace Groep9.NET.Controllers
{
    [Authorize]
    public class VerlanglijstController : Controller
    {
        private IProductRepository productRepository;
        private IDoelgroepRepository doelgroepRepository;
        private ILeergebiedRepository leergebiedRepository;
        private IGebruikerRepository gebruikerRepository;
        //private IReservatieRepository reservatieRepository;
        
        // GET: Verlanglijst
        public VerlanglijstController(IProductRepository pr, IDoelgroepRepository dr, ILeergebiedRepository lr, IGebruikerRepository gr/*, IReservatieRepository rr*/)
        {
            productRepository = pr;
            doelgroepRepository = dr;
            leergebiedRepository = lr;
            gebruikerRepository = gr;
            //reservatieRepository = rr;
        }

        public ActionResult Index(Gebruiker gebruiker, string datum)
        {
            IEnumerable<Product> verlanglijst = gebruiker.VerlangLijst.ToList();

            ProductenViewModel vm = new ProductenViewModel()
            {
                Producten = verlanglijst.Select(p => new ProductViewModel(p, gebruiker))
            };

            if (Request.IsAjaxRequest())
                return PartialView("Producten", vm.Producten);

            return View(vm);
        }

        public ActionResult RemoveFromVerlanglijst(int id, Gebruiker gebruiker)
        {
            try {
                
                gebruiker.VerwijderProductUitVerlanglijst(productRepository.FindByProductNummer(id));
                gebruikerRepository.SaveChanges();
                IList<Product> verlanglijst = gebruiker.VerlangLijst.ToList();
                return RedirectToAction("Index"); }
            catch
            {
                TempData["DeleteFail"] = "Verwijderen van verlanglijst is niet gelukt";

                return RedirectToAction("Index");
            }

        }


        public ActionResult AddReservatie(Gebruiker gebruiker ,int aantal, int id)
        {
            try
            {
                //productRepository.ReserveerProduct(product, aantal);

                //methode voor reserveerknop, die aantal meegeeft aan methode product.Reserveer
                Reservatie reservatie = new Reservatie(productRepository.FindByProductNummer(id), aantal,gebruiker);
                reservatie.Product.AantalGereserveerd += aantal;
                reservatie.Product.AantalBeschikbaar -= aantal;               
                gebruiker.VoegReservatieToe(reservatie);
                gebruikerRepository.SaveChanges();
                
                TempData["Info"] = "Product " + productRepository.FindByProductNummer(id).Naam + " is gereserveerd.";
            }
            catch
            {
                TempData["ReservatieFail"] = "Reservatie toevoegen is niet gelukt";



            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            try {
                
                return View(productRepository.FindByProductNummer(id));
            }
            catch 
            {
                TempData["DetailsFail"] = "Details weergeven is niet gelukt";


                return RedirectToAction("Index");
            }
            
        }

    }
}