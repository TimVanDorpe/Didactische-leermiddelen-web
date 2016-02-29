using Groep9.NET.Models.DAL;
using Groep9.NET.Models.Domein;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Groep9.NET.Controllers
{
    [AllowAnonymous]
    public class CatalogusController : Controller
    {
        // GET: Catalogus

        private IProductRepository productRepository;
        private IDoelgroepRepository doelgroepRepository;
        private ILeergebiedRepository leergebiedRepository;
        private IGebruikerRepository gebruikerRepository;
      //  private ApplicationDbContext adc;
       

        public CatalogusController(IProductRepository pr, IDoelgroepRepository dr, ILeergebiedRepository lr, IGebruikerRepository gr)
        {
            productRepository = pr;
            doelgroepRepository = dr;
            leergebiedRepository = lr;
           gebruikerRepository = gr;
            
        }
    
        public ActionResult Index( string trefwoord = "", string doelgroep = "", string leergebied = "")
        {
            //if (prodId >= 0)
            //{
            //    AddToVerlanglijst(prodId, gebruikerRepository.FindByEmail(User.Identity.Name));
            //}
          
                    if (doelgroep.Equals("-- Selecteer doelgroep --"))
                        {
                            doelgroep = "";
                        }
                    if (leergebied.Equals("-- Selecteer doelgroep --"))
                    {
                        leergebied = "";
                    }
                     IEnumerable<Product> producten = productRepository.VindAlleProducten().ToList();



                    if (!trefwoord.Equals(""))
                    {
               
                        producten =
                            producten.Where(p => p.Naam.ToLower().Contains(trefwoord.ToLower()) || p.Omschrijving.ToLower().Contains(trefwoord.ToLower()));
                

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

            if (Request.IsAjaxRequest())
                        return PartialView("Producten", producten);
                    
                    

                    return View(producten);
               
                
                      
           // return RedirectToAction("Index", "Home");
        }
      

        private SelectList GetDoelgroepSelectList()
        {
                                 
                     
         //   return new SelectList(productRepository.VindAlleProducten().Include(p => p.Doelgroepen.Select(g => g.Naam)).ToList());
            return new SelectList(doelgroepRepository.VindAlleDoelgroepen().Select(p=>p.Naam));

        }
        private SelectList GetLeergebiedSelectList()
        {
            return new SelectList(leergebiedRepository.VindAlleLeergebieden().Select(p=>p.Naam));
           // return new SelectList(productRepository.VindAlleProducten().Include(p => p.Leergebieden.Select(g => g.Naam)).ToList());


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

        public ActionResult AddToVerlanglijst(int id, Gebruiker gebruiker)
        {
            // Gebruiker currentUser = gebruikerRepository.FindByEmail(User.Identity.Name);
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("login", "Account");
            }
           
                Product product = productRepository.FindByProductNummer(id);
                gebruiker.VoegProductAanVerlanglijstToe(product);
            gebruikerRepository.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Verlanglijst(Gebruiker gebruiker)
        {
            string email = gebruiker.Email;
           // Gebruiker currentUser =  gebruikerRepository.FindByEmail(User.Identity.Name);
            IList<Product> verlanglijst = gebruiker.VerlangLijst.ToList();
            return View(verlanglijst);
        }
    }
}