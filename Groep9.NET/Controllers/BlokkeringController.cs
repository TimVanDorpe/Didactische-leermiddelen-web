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


        private IProductRepository productRepository;
        private IDoelgroepRepository doelgroepRepository;
        private ILeergebiedRepository leergebiedRepository;
        private IGebruikerRepository gebruikerRepository;

        public BlokkeringController(IProductRepository pr, IDoelgroepRepository dr, ILeergebiedRepository lr, IGebruikerRepository gr/*, IReservatieRepository rr*/)
        {
            productRepository = pr;
            doelgroepRepository = dr;
            leergebiedRepository = lr;
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

                Blokkering blokkering = gebruiker.BlokkeringLijst.First();
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