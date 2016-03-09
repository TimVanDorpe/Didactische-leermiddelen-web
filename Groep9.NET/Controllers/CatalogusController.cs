using Groep9.NET.Models.DAL;
using Groep9.NET.Models.Domein;
using Groep9.NET.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Groep9.NET.Controllers {
    [Authorize]
    public class CatalogusController : Controller
    {
        // GET: Catalogus

        private IProductRepository productRepository;
        private IDoelgroepRepository doelgroepRepository;
        private ILeergebiedRepository leergebiedRepository;
        private IGebruikerRepository gebruikerRepository;

        public CatalogusController(IProductRepository pr, IDoelgroepRepository dr, ILeergebiedRepository lr, IGebruikerRepository gr)
        {
            productRepository = pr;
            doelgroepRepository = dr;
            leergebiedRepository = lr;
            gebruikerRepository = gr;
        }

        public ActionResult Index(Gebruiker gebruiker, string trefwoord = "", string doelgroep = "", string leergebied = "")
        {
            IEnumerable<Product> producten = productRepository.VindAlleProducten().ToList();
            if (!trefwoord.Equals(""))
            {
                producten =
                    producten.Where(
                        p =>
                            p.Naam.ToLower().Contains(trefwoord.ToLower()) ||
                            p.Omschrijving.ToLower().Contains(trefwoord.ToLower()));
            }

            if (gebruiker is Student)
            {
                producten = producten.Where(p => p.Uitleenbaarheid);
            }
            if (!doelgroep.Equals(""))
            {
                producten = producten.Where(p => p.Doelgroepen.Any(d => d.Naam.Equals(doelgroep)));
            }
            if (!leergebied.Equals(""))
            {
                producten = producten.Where(p => p.Leergebieden.Any(d => d.Naam.Equals(leergebied)));
            }

            FillDropDownList();

            ProductenViewModel vm = new ProductenViewModel()
            {
                Producten = producten.Select(p => new ProductViewModel(p, gebruiker))
            };

            if (Request.IsAjaxRequest())
                return PartialView("Producten", vm.Producten);

            return View(vm);

        }


        private SelectList GetDoelgroepSelectList()
        {
            return new SelectList(doelgroepRepository.VindAlleDoelgroepen().Select(p => p.Naam));

        }
        private SelectList GetLeergebiedSelectList()
        {
            return new SelectList(leergebiedRepository.VindAlleLeergebieden().Select(p => p.Naam));

        }
        public ActionResult Details(int id)
        {
            Product product = productRepository.FindByProductNummer(id);
            return View(product);
        }

        public void FillDropDownList()
        {

            ViewBag.leergebied = GetLeergebiedSelectList();
            ViewBag.doelgroep = GetDoelgroepSelectList();

        }
        public Boolean CheckVerlanglijst(int id, Gebruiker gebruiker)
        {
            Product product = productRepository.FindByProductNummer(id);
            if (gebruiker.VerlangLijst.Contains(product))
            {
                return true;
            }
            else {
                return false;
            }
        }


        //public ActionResult AddToVerlanglijst(int id, Gebruiker gebruiker)
        //{
           

        //        try
        //        {
        //            Product product = productRepository.FindByProductNummer(id);
        //            gebruiker.VoegProductAanVerlanglijstToe(product);
        //            gebruikerRepository.SaveChanges();
               
        //        return RedirectToAction("Index");
        //        }
        //        catch 
        //        {
        //            ModelState.AddModelError("", "Reservatie is niet toegevoegd");
        //            return RedirectToAction("Index");

        //        }

        //}
    
    public ActionResult AddOfVerwijderVerlanglijst(int id, Gebruiker gebruiker) {
            try {

                if (!CheckVerlanglijst(id, gebruiker)) {
                    Product product = productRepository.FindByProductNummer(id);
                    gebruiker.VoegProductAanVerlanglijstToe(product);
                    gebruikerRepository.SaveChanges();
                    TempData["Info"] = "Product " + product.Naam + " is toegevoegd aan verlanglijst.";
                }
                else {
                    Product product = productRepository.FindByProductNummer(id);
                    gebruiker.VerwijderProductUitVerlanglijst(product);
                    gebruikerRepository.SaveChanges();
                    TempData["Info"] = "Product " + product.Naam + " is verwijderd uit verlanglijst.";
                }
                // Gebruiker currentUser = gebruikerRepository.FindByEmail(User.Identity.Name);

                return RedirectToAction("Index"); }
            catch 
            {
                ModelState.AddModelError("", "Toevoegen/Verwijderen aan verlanglijst is niet gelukt");
                return RedirectToAction("Index");

            }
        }



    }
}