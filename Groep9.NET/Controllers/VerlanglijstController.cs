using Groep9.NET.Models.Domein;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        private DateTime ZetDatumOm(string datum)
        {
            if (datum == null)
            {
                //als er geen datum geselecteerd is, stel tempdata in op vandaag
                datum = DateTime.ParseExact(DateTime.Today.ToString().Substring(0, 10), "dd/MM/yyyy", null).ToString("dd/MM/yyyy");

            }
            return new DateTime(Int32.Parse(datum.Substring(6, 4)), Int32.Parse(datum.Substring(3, 2)), Int32.Parse(datum.Substring(0, 2)));
        }

        public ActionResult Index(Gebruiker gebruiker, string datum ) {

            try {

                IEnumerable<Product> verlanglijst = gebruiker.VerlangLijst.ToList();
                Reservatie r = new Reservatie();

                DateTime date = ZetDatumOm(datum);
                   
                
                    //anders op geselecteerde datum
                    TempData["datum"] = date.ToString("dd/MM/yyyy");
                



                //stelt de start en einddatum in voor in de bevestigingspopup weer te geven
                TempData["startdatum"] = r.BerekenStartDatumReservatieWeek(date);
                TempData["einddatum"] = r.BerekenEindDatumReservatieWeek(date);


                ProductenViewModel vm = new ProductenViewModel() {
                    Producten = verlanglijst.Select(p => new ProductViewModel(p, gebruiker, p.BerekenAantalGereserveerdOpWeek(date),p.BerekenAantalGeblokkeerdOpWeek(date)))
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
              
                if (gebruiker is Student) {
                    Product prod = productRepository.FindByProductNummer(id);

                    //methode voor reserveerknop, die aantal meegeeft aan methode product.Reserveer

                    DateTime date = ZetDatumOm(datum);
                    if (prod.Aantal > (prod.BerekenAantalGereserveerdOpWeek(date) + aantal))
                    {
                        if (aantal > 0)
                        {
                        ReservatieAbstr reservatie = new Reservatie(prod, aantal, gebruiker, date);
                        gebruiker.VoegReservatieAbstrToe(reservatie);
                        gebruikerRepository.SaveChanges();
                        TempData["Info"] = "Product " + productRepository.FindByProductNummer(id).Naam +
                                           " is gereserveerd.";
                    }
                    else
                    {
                            TempData["ReservatieFail"] = "Aantal moet positief zijn";
                        }
                    }

                    else
                    {
                        TempData["ReservatieFail"] = "Er zijn niet genoeg producten beschikbaar.";
                    }
                }
                            
                else {
                    TempData["ReservatieFail"] = "Reservatie toevoegen lukt niet als leerkracht.";
                }


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
            Product prod = productRepository.FindByProductNummer(id);
            try
            {
                
                               
              
                if (gebruiker is Personeelslid)
                {
                    DateTime date = ZetDatumOm(datum);
                    if (prod.Aantal > (prod.BerekenAantalGereserveerdOpWeek(date) + aantal))
                    {
                        if (aantal > 0)
                        {
                            ReservatieAbstr blokkering = new Blokkering(prod, aantal, gebruiker, date);
                           // blokkering.addWeekdag(Maandag, Dinsdag, Woensdag, Donderdag, Vrijdag);
                            
                            gebruiker.VoegReservatieAbstrToe(blokkering);
                            gebruikerRepository.SaveChanges();
                            TempData["Info"] = "Product " + productRepository.FindByProductNummer(id).Naam + " is geblokkeerd.";
                        }
                        else
                        {
                            TempData["ReservatieFail"] = "Aantal moet positief zijn";
                        }
                    }
                    else
                    {
                        TempData["ReservatieFail"] = "Er zijn niet genoeg producten beschikbaar.";
                    }

                }
                else {
                    TempData["ReservatieFail"] = "Blokkering toevoegen lukt niet als Student";
                }

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
        
        public ActionResult Details(int id) {
            try {

                return View(productRepository.FindByProductNummer(id));
            }
            catch {
                TempData["DetailsFail"] = "Details weergeven is niet gelukt";


                return RedirectToAction("Index");
            }

        }
        

    }
}