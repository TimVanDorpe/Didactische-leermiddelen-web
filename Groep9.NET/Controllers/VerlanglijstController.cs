using Groep9.NET.Models.Domein;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Groep9.NET.Helpers;
using Groep9.NET.ViewModels;

namespace Groep9.NET.Controllers {
    [Authorize]
    public class VerlanglijstController : Controller {
        private IProductRepository productRepository;        
        private IGebruikerRepository gebruikerRepository;
        //List<Dag> weekdagen = new List<Dag>();

        // GET: Verlanglijst
        public VerlanglijstController(IProductRepository pr, IGebruikerRepository gr) {
            productRepository = pr;
            gebruikerRepository = gr;
        }

        public ActionResult Index(Gebruiker gebruiker, string datum ) {

            try {

                IEnumerable<Product> verlanglijst = gebruiker.VerlangLijst.ToList();

                DateTime date = Helper.ZetDatumOm(datum);
                   
                
                    //anders op geselecteerde datum
                    TempData["datum"] = date.ToString("dd/MM/yyyy");
                



                //stelt de start en einddatum in voor in de bevestigingspopup weer te geven
                TempData["startdatum"] = Helper.BerekenStartDatumReservatieWeek(date);
                TempData["einddatum"] = Helper.BerekenEindDatumReservatieWeek(date);
                

                ProductenViewModel vm = new ProductenViewModel() {
                    Producten = verlanglijst.Select(p => new ProductViewModel(p, gebruiker, p.BerekenAantalReservatiesOfBlokkeringenOpWeek(date,"reservatie"),p.BerekenAantalReservatiesOfBlokkeringenOpWeek(date, "blokkering")))
                };

                if (Request.IsAjaxRequest())
                    return PartialView("Producten", vm.Producten);

                return View(vm);
            }

            catch (ArgumentException e) {
                TempData["ReservatieFail"] = e.Message;
                return RedirectToAction("Index");
            }
        }




        public ActionResult RemoveFromVerlanglijst(int id, Gebruiker gebruiker) {
            try {

                gebruiker.VerwijderProductUitVerlanglijst(productRepository.FindByProductNummer(id));
                gebruikerRepository.SaveChanges();
                IList<Product> verlanglijst = gebruiker.VerlangLijst.ToList();
                return RedirectToAction("Index");
            }
            catch {
                TempData["DeleteFail"] = "Verwijderen van verlanglijst is niet gelukt";

                return RedirectToAction("Index");
            }

        }


        public ActionResult AddReservatie(Gebruiker gebruiker, int aantal, int id, string datum) {
            try {
              
               
                    Product prod = productRepository.FindByProductNummer(id);

                    //methode voor reserveerknop, die aantal meegeeft aan methode product.Reserveer

                    DateTime date = Helper.ZetDatumOm(datum);
                    ReservatieAbstr reservatie = new Reservatie(prod, aantal, gebruiker, date);


                        gebruiker.VoegReservatieAbstrToe(reservatie);
                        gebruikerRepository.SaveChanges();
                        TempData["Info"] = "Product " + productRepository.FindByProductNummer(id).Naam +
                                           " is gereserveerd.";
                   

            }
            catch (ArgumentException e) {
                TempData["ReservatieFail"] = e.Message;
            }
            catch {
                TempData["ReservatieFail"] = "Reservatie toevoegen is niet gelukt";


            }


            return RedirectToAction("Index");
        }
        public ActionResult AddBlokkering(Gebruiker gebruiker, int aantal, int id, string datum , bool Maandag = false , bool Dinsdag = false, bool Woensdag = false, bool Donderdag = false, bool Vrijdag = false)
        {
            
            try
            {
                Product prod = productRepository.FindByProductNummer(id);
                DateTime date = Helper.ZetDatumOm(datum);
                ReservatieAbstr blokkering = new Blokkering(prod, aantal, gebruiker, date);
                           // blokkering.addWeekdag(Maandag, Dinsdag, Woensdag, Donderdag, Vrijdag);
                            
                            gebruiker.VoegReservatieAbstrToe(blokkering);
                            gebruikerRepository.SaveChanges();
                            TempData["Info"] = "Product " + productRepository.FindByProductNummer(id).Naam + " is geblokkeerd.";
                      

            }
            catch (ArgumentException e)
            {
                TempData["ReservatieFail"] = e.Message;
            }
            catch
            {
                TempData["ReservatieFail"] = "Blokkering toevoegen is niet gelukt";


            }


            return RedirectToAction("Index");
        }
        
        public ActionResult Details(int id, string datum) {
            try
            {

                TempData["selectedDate"] = Helper.ZetDatumOm(datum);

                return View(productRepository.FindByProductNummer(id));
            }
            catch {
                TempData["DetailsFail"] = "Details weergeven is niet gelukt";


                return RedirectToAction("Index");
            }

        }
        

    }
}