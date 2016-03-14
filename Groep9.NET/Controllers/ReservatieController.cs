using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Groep9.NET.Models.Domein;

namespace Groep9.NET.Controllers
{
    [Authorize]
    public class ReservatieController : Controller
    {
        private IProductRepository productRepository;
        private IDoelgroepRepository doelgroepRepository;
        private ILeergebiedRepository leergebiedRepository;
        private IGebruikerRepository gebruikerRepository;
        //private IReservatieRepository reservatieRepository;

        public ReservatieController(IProductRepository pr, IDoelgroepRepository dr, ILeergebiedRepository lr, IGebruikerRepository gr/*, IReservatieRepository rr*/)
        {
            productRepository = pr;
            doelgroepRepository = dr;
            leergebiedRepository = lr;
            gebruikerRepository = gr;
            //reservatieRepository = rr;
        }

        // GET: Reservatie
        public ActionResult Index(Gebruiker gebruiker)
        {
            IList<Reservatie> reservatielijst = gebruiker.ReservatieLijst.ToList();
               // reservatieRepository.VindAlleReservaties().Where(r=>r.Gebruiker.Email == gebruiker.Email).ToList();


            return View(reservatielijst);
        }
       
             public ActionResult RemoveFromReservatieLijst(int id,Gebruiker gebruiker)
        {
            try
            {               
                
                Reservatie reservatie = gebruiker.ReservatieLijst.First();
                gebruiker.VerwijderReservatie(reservatie);
                reservatie.Product.AantalGereserveerd--;
                reservatie.Product.AantalBeschikbaar++;
                gebruikerRepository.SaveChanges();
               
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["DeleteFail"] = "Verwijderen van reservatie is niet gelukt";

                return RedirectToAction("Index");
            }

        }
    }
}