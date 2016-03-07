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

        public ReservatieController(IProductRepository pr, IDoelgroepRepository dr, ILeergebiedRepository lr, IGebruikerRepository gr)
        {
            productRepository = pr;
            doelgroepRepository = dr;
            leergebiedRepository = lr;
            gebruikerRepository = gr;
        }

        // GET: Reservatie
        public ActionResult Index(Gebruiker gebruiker, int aantal = 0, int productnummer = 0)
        {
            Product product = productRepository.FindByProductNummer(productnummer);
            productRepository.ReserveerProduct(product, aantal);
            
            DateTime start = productRepository.BerekenStartDatumReservatieWeek();
            DateTime eind = productRepository.BerekenEindDatumReservatieWeek();

            gebruikerRepository.ReserveerProduct(product, start, eind, aantal, gebruiker);
            return View(gebruiker.ReservatieLijst);
        }
    }
}