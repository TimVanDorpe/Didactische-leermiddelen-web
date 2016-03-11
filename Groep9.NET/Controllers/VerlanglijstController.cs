using Groep9.NET.Models.Domein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Groep9.NET.Controllers
{
    [Authorize]
    public class VerlanglijstController : Controller
    {
        private IProductRepository productRepository;
        private IDoelgroepRepository doelgroepRepository;
        private ILeergebiedRepository leergebiedRepository;
        private IGebruikerRepository gebruikerRepository;
        private IReservatieRepository reservatieRepository;
        
        // GET: Verlanglijst
        public VerlanglijstController(IProductRepository pr, IDoelgroepRepository dr, ILeergebiedRepository lr, IGebruikerRepository gr, IReservatieRepository rr)
        {
            productRepository = pr;
            doelgroepRepository = dr;
            leergebiedRepository = lr;
            gebruikerRepository = gr;
            reservatieRepository = rr;
        }

        public ActionResult Index(Gebruiker gebruiker)
        {
            IList<Product> verlanglijst = gebruiker.VerlangLijst.ToList();
            return View(verlanglijst);
        }

        public ActionResult RemoveFromVerlanglijst(int id, Gebruiker gebruiker)
        {
            try {
                Product product = productRepository.FindByProductNummer(id);
                gebruiker.VerwijderProductUitVerlanglijst(product);
                gebruikerRepository.SaveChanges();
                IList<Product> verlanglijst = gebruiker.VerlangLijst.ToList();
                return RedirectToAction("Index"); }
            catch
            {
                TempData["DeleteFail"] = "Verwijderen van verlanglijst is niet gelukt";

                return RedirectToAction("Index");
            }

        }


        public ActionResult AddReservatie(Gebruiker gebruiker ,int aantal = 0, int productnummer = 0)
        {
            try
            {
                Product product = productRepository.FindByProductNummer(productnummer);
                productRepository.ReserveerProduct(product, aantal);

                //methode voor reserveerknop, die aantal meegeeft aan methode product.Reserveer
                Reservatie reservatie = new Reservatie(product, aantal,gebruiker);
                gebruiker.ReservatieLijst.Add(reservatie);
                reservatieRepository.AddReservatie(reservatie);
                reservatieRepository.SaveChanges();
                
                TempData["Info"] = "Product " + product.Naam + " is gereserveerd.";
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
                Product product = productRepository.FindByProductNummer(id);
                return View(product);
            }
            catch 
            {
                TempData["DetailsFail"] = "Details weergeven is niet gelukt";


                return RedirectToAction("Index");
            }
            
        }

    }
}