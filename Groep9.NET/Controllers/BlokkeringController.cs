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
        public BlokkeringController(IGebruikerRepository gr/*, IReservatieRepository rr*/)
        {                    
            gebruikerRepository = gr;
        }
        // GET: Blokkering
        public ActionResult Index(Gebruiker gebruiker)
        {
            IList<Blokkering> blokkeringlijst = gebruiker.BlokkeringLijst.ToList();
            return View(blokkeringlijst);
        }

        public ActionResult RemoveFromBlokkeringLijst(int id, Gebruiker gebruiker)
            {
            try
            {

                Blokkering blokkering = gebruiker.BlokkeringLijst.FirstOrDefault(b=> b.BlokkeringId == id);
                gebruiker.VerwijderBlokkering(blokkering);

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