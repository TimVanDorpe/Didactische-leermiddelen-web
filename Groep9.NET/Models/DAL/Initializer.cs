using System;
using System.Data.Entity.Validation;
using System.Data.Entity;
using Groep9.NET.Models.Domein;
using System.Collections.Generic;

namespace Groep9.NET.Models.DAL
{
    public class Initializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            try
            {

               Doelgroep Kleuters = new Doelgroep("Kleuters");
                Doelgroep LagereSchool = new Doelgroep("Lagere School"); //manier 1

                Leergebied Kaarten = new Leergebied("Kaartprojectie");//manier 2
                Leergebied Kansen = new Leergebied("Kansberekening");
                Leergebied Tellen = new Leergebied("Tellen");
                Leergebied Behendigheid = new Leergebied("Behendigheid"); // 2 vss manieren om dit te proberen doen werken, geen van beide die dus werkt..
                
                context.Doelgroepen.Add(Kleuters);
                context.Doelgroepen.Add(LagereSchool);
                context.SaveChanges();

                context.Leergebieden.Add(Kaarten);
                context.Leergebieden.Add(Kansen);
                context.Leergebieden.Add(Tellen);
                context.Leergebieden.Add(Behendigheid);
                context.SaveChanges();

                Product landkaart = new Product("landkaart.jpg", "Landkaart", "Map van België", 8.55, 20, false, "Aalst", "Hogent", new List<Doelgroep> { LagereSchool }, new List<Leergebied> {Kaarten  });
                Product rekenmachine = new Product("rekenmachine.jpg", "Rekenmachine", "Rekenmachine van merk X", 8.55, 10, false, "Aalst", "Hogent", new List<Doelgroep> { LagereSchool }, new List<Leergebied> { Tellen });
                Product dobbelsteenschatkist = new Product("dobbelsteen.jpg", "Dobbelsteen schatkist", "koffertje met verschillende soorten dobbelstenen: blanco, met cijfers", 35, 12, true, "GLEDE 1.011", "Hogent", new List<Doelgroep> { Kleuters, LagereSchool }, new List<Leergebied> { Kansen, Tellen });
                Product blancodraaischijf = new Product("blanco_draaischijf.PNG", "Blanco schijf", "Met verschillende blanco schijven in hard papier", 31.45, 1, true, "GLEDE 1.011", "HoGent", new List<Doelgroep> { Kleuters }, new List<Leergebied> { Behendigheid });
                Product spinnersKlassAss = new Product("Magnspinner.jpg", "Magnetische spinner", "Magnetische spinners in de vorm van een pijl, een vinger en een potlood", 19.2, 13, true, "GLEDE 1.011", "Hogent", new List
                    <Doelgroep> { Kleuters }, new List<Leergebied> { Behendigheid });

                Gebruiker student = new Student
                {
                    Email = "student@hogent.be"
                };
                Gebruiker personeelslid = new Personeelslid
                {
                    Email = "personeel@hogent.be"                  
                };
           

                context.Gebruikers.Add(student);
                context.Gebruikers.Add(personeelslid);

               
                context.Producten.Add(rekenmachine);
                context.Producten.Add(landkaart);
                context.Producten.Add(dobbelsteenschatkist);
                context.Producten.Add(blancodraaischijf);
                context.Producten.Add(spinnersKlassAss);
                context.SaveChanges();




            }
            catch (DbEntityValidationException e)
            {
                string s = "Fout creatie database ";
                foreach (var eve in e.EntityValidationErrors)
                {
                    s += String.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.GetValidationResult());
                    foreach (var ve in eve.ValidationErrors)
                    {
                        s += String.Format("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw new Exception(s);
            }
        }
    }
}