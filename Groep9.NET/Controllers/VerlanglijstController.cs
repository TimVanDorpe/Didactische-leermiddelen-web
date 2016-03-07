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
        
        // GET: Verlanglijst
        public VerlanglijstController(IProductRepository pr, IDoelgroepRepository dr, ILeergebiedRepository lr, IGebruikerRepository gr)
        {
            productRepository = pr;
            doelgroepRepository = dr;
            leergebiedRepository = lr;
            gebruikerRepository = gr;
        }

        public ActionResult Index(Gebruiker gebruiker)
        {
            IList<Product> verlanglijst = gebruiker.VerlangLijst.ToList();
            return View(verlanglijst);
        }

        public ActionResult RemoveFromVerlanglijst(int id, Gebruiker gebruiker)
        {
            Product product = productRepository.FindByProductNummer(id);
            gebruiker.verwijderProductUitVerlanglijst(product);
            gebruikerRepository.SaveChanges();
            IList<Product> verlanglijst = gebruiker.VerlangLijst.ToList();
            return RedirectToAction("Index");
        }

        //methode voor reserveerknop, die aantal meegeeft aan methode product.Reserveer
        public ActionResult Reservatie(Gebruiker gebruiker, int aantal = 0, int productnummer = 0)
        {
            Product product = productRepository.FindByProductNummer(productnummer);
            productRepository.ReserveerProduct(productnummer, aantal);
            
            DateTime start = productRepository.BerekenStartDatumReservatieWeek();
            DateTime eind = productRepository.BerekenEindDatumReservatieWeek();

            gebruiker.ReservatieLijst.Add(new Reservatie(product, start, eind, aantal));
            //gebruikerRepository.ReserveerProduct(product, start, end, aantal, gebruiker);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id) {
            Product product = productRepository.FindByProductNummer(id);
            return View(product);
        }

    }
}