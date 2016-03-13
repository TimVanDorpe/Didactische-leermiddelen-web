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
       
             public ActionResult RemoveFromReservatieLijst(int id, Reservatie reservatie, Gebruiker gebruiker)
        {
            try
            {
                
                gebruiker.VerwijderReservatie(reservatie);
                gebruikerRepository.SaveChanges();
               
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Verwijderen van reservatielijst is mislukt");
                return RedirectToAction("Index");
            }

        }
    }
}