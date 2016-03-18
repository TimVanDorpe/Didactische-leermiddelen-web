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
      
        private IGebruikerRepository gebruikerRepository;

        public ReservatieController( IGebruikerRepository gr)
        {
            
            gebruikerRepository = gr;
        }

        // GET: Reservatie
        public ActionResult Index(Gebruiker gebruiker)
        {
            IList<ReservatieAbstr> reservatielijst = gebruiker.ReservAbstrLijst.ToList();
            return View(reservatielijst);
        }
       
             public ActionResult RemoveFromReservatieLijst(int id,Gebruiker gebruiker)
        {
            try
            {    
                ReservatieAbstr reservatie = gebruiker.ReservAbstrLijst.FirstOrDefault(b => b.ReservatieAbstrId == id);
                gebruiker.VerwijderReservatieAbstr(reservatie);
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