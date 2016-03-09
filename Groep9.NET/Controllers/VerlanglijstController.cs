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
            gebruiker.VerwijderProductUitVerlanglijst(product);
            gebruikerRepository.SaveChanges();
            IList<Product> verlanglijst = gebruiker.VerlangLijst.ToList();
            return RedirectToAction("Index");
        }

     
        public ActionResult Details(int id)
        {
            Product product = productRepository.FindByProductNummer(id);
            return View(product);
        }

    }
}