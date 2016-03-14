using Groep9.NET.Models.Domein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Groep9.NET.ViewModels;

namespace Groep9.NET.Controllers
{
    [Authorize]
    public class BlokkadeController : Controller
    {
        private IProductRepository productRepository;
        private IDoelgroepRepository doelgroepRepository;
        private ILeergebiedRepository leergebiedRepository;
        private IGebruikerRepository gebruikerRepository;
       
        public BlokkadeController(IProductRepository pr, IDoelgroepRepository dr, ILeergebiedRepository lr, IGebruikerRepository gr/*, IReservatieRepository rr*/)
        {
            productRepository = pr;
            doelgroepRepository = dr;
            leergebiedRepository = lr;
            gebruikerRepository = gr;
            
        }

        public ActionResult Index(Gebruiker gebruiker, string datum)
        {
            IEnumerable<Product> verlanglijst = gebruiker.VerlangLijst.ToList();

            ProductenViewModel vm = new ProductenViewModel()
            {
                Producten = verlanglijst.Select(p => new ProductViewModel(p, gebruiker))
            };

            if (Request.IsAjaxRequest())
                return PartialView("Producten", vm.Producten);

            return View(vm);
        }
        public ActionResult Blokkeer(int id = 0, int aantal = 1)
        {
            productRepository.FindByProductNummer(id).AantalGeblokkeerd += aantal;
            productRepository.FindByProductNummer(id).AantalBeschikbaar -= aantal;
            
            
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            try
            {

                return View(productRepository.FindByProductNummer(id));
            }
            catch
            {
                TempData["DetailsFail"] = "Details weergeven is niet gelukt";


                return RedirectToAction("Index");
            }

        }

    }
}