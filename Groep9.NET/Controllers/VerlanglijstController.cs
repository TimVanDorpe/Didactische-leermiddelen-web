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
        private IDoelgroepRepository doelgroepRepository;
        private ILeergebiedRepository leergebiedRepository;
        private IGebruikerRepository gebruikerRepository;
        List<Dag> weekdagen = new List<Dag>();

        // GET: Verlanglijst
        public VerlanglijstController(IProductRepository pr, IDoelgroepRepository dr, ILeergebiedRepository lr, IGebruikerRepository gr) {
            productRepository = pr;
            doelgroepRepository = dr;
            leergebiedRepository = lr;
            gebruikerRepository = gr;
        }

        public ActionResult Index(Gebruiker gebruiker, string datum ) {

            try {

                IEnumerable<Product> verlanglijst = gebruiker.VerlangLijst.ToList();
                Reservatie r = new Reservatie();

                if (datum == null) {
                    //als er geen datum geselecteerd is, stel tempdata in op vandaag
                    datum =
                        DateTime.ParseExact(DateTime.Today.ToString().Substring(0, 10), "dd/MM/yyyy", null)
                            .ToString("MM/dd/yyyy");
                   
                }
                
                    //anders op geselecteerde datum
                    TempData["datum"] = datum;
                



                //stelt de start en einddatum in voor in de bevestigingspopup weer te geven
                TempData["startdatum"] = r.BerekenStartDatumReservatieWeek(datum);
                TempData["einddatum"] = r.BerekenEindDatumReservatieWeek(datum);


                ProductenViewModel vm = new ProductenViewModel() {
                    Producten = verlanglijst.Select(p => new ProductViewModel(p, gebruiker, p.BerekenAantalGereserveerdOpWeek(datum),p.BerekenAantalGeblokkeerdOpWeek(datum)))
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

               
                if (gebruiker is Student) {
                    if (prod.Aantal > (prod.BerekenAantalGereserveerdOpWeek(datum) + aantal))
                    {
                        if (aantal > 0)
                        {
                        Reservatie reservatie = new Reservatie(prod, aantal, gebruiker, datum);
                        prod.VoegReservatieToe(reservatie);
                        gebruiker.VoegReservatieToe(reservatie);
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
                
                Product prod = productRepository.FindByProductNummer(id);                
                Blokkering blokkering = new Blokkering(prod, aantal, gebruiker, datum);
                addWeekdag(Maandag, Dinsdag, Woensdag, Donderdag, Vrijdag);
                blokkering.Weekdagen = weekdagen;
                prod.VoegBlokkeringToe(blokkering);
                if (gebruiker is Personeelslid)
                {
                    if (prod.Aantal > (prod.BerekenAantalGereserveerdOpWeek(datum) + aantal))
                    {
                        if (aantal > 0)
                        {
                   
                            Blokkering blokkering = new Blokkering(prod, aantal, gebruiker, datum);
                            if (Maandag)
                            {
                                blokkering.addWeekdag("Maandag");
                            }
                            prod.VoegBlokkeringToe(blokkering);
                    gebruiker.VoegBlokkeringToe(blokkering);
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
        public void addWeekdag(bool Maandag, bool Dinsdag, bool Woensdag, bool Donderdag, bool Vrijdag)
        {
            if (Maandag == true)
            {
                Dag Ma = new Dag("Maandag");
                weekdagen.Add(Ma);
            }
            if (Dinsdag == true)
            {
                Dag Di = new Dag("Dinsdag");
                weekdagen.Add(Di);
            }
            if (Woensdag == true)
            {
                Dag Wo = new Dag("Woensdag");
                weekdagen.Add(Wo);
            }
            if (Donderdag == true)
            {
                Dag Do = new Dag("Donderdag");
                weekdagen.Add(Do);
            }
            if (Vrijdag == true)
            {
                Dag Vr = new Dag("Vrijdag");
                weekdagen.Add(Vr);
            }

        }

    }
}