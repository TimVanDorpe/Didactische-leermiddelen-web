using Groep9.NET.Models.Domein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Groep9.NET.Controllers
{
    public class BlokkeringController : Controller
    {
        private IGebruikerRepository gebruikerRepository;
        
        public BlokkeringController(IGebruikerRepository gr)
        {
        
            gebruikerRepository = gr;
        }
        // GET: Blokkering
        public ActionResult Index(Gebruiker gebruiker)
        {
            IList<ReservatieAbstr> blokkeringlijst = gebruiker.ReservAbstrLijst.ToList();
            return View(blokkeringlijst);
        }

        public ActionResult RemoveFromBlokkeringLijst(int id, Gebruiker gebruiker)
            {
            try
            {

                ReservatieAbstr blokkering = gebruiker.ReservAbstrLijst.FirstOrDefault(b=> b.ReservatieAbstrId == id);
                gebruiker.VerwijderReservatieAbstr(blokkering);

                gebruikerRepository.SaveChanges();

            return RedirectToAction("Index");
        }
            catch
            {
                TempData["DeleteFail"] = "Verwijderen van blokkering is niet gelukt";

                return RedirectToAction("Index");
            }

        }
    }
}