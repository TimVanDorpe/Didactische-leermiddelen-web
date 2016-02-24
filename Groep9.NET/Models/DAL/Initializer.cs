﻿using System;
using System.Data.Entity.Validation;
using System.Data.Entity;
using Groep9.NET.Models.Domein;

namespace Groep9.NET.Models.DAL
{
    public class Initializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            try
            {

               Doelgroep Kleuters = new Doelgroep("kleuters");
                Doelgroep LagereSchool = new Doelgroep("Lagere School"); //manier 1

                Leergebied Kaarten = new Leergebied("Kaartprojectie");//manier 2
                Leergebied Kansen = new Leergebied("Kansberekening");
                Leergebied Tellen = new Leergebied("Tellen");
                Leergebied Behendigheid = new Leergebied("Behendigheid"); // 2 vss manieren om dit te proberen doen werken, geen van beide die dus werkt..
                
                context.Doelgroepen.Add(Kleuters);
                context.Doelgroepen.Add(LagereSchool);

                context.Leergebieden.Add(Kaarten);
                context.Leergebieden.Add(Kansen);
                context.Leergebieden.Add(Tellen);
                context.Leergebieden.Add(Behendigheid);
                context.SaveChanges();

                Product landkaart = new Product("landkaart.jpg", 4, "Landkaart", "Map van België", 8.55, 10, false, "Aalst", "Hogent", LagereSchool, Kaarten);
                Product rekenmachine = new Product("rekenmachine.jpg", 5, "Rekenmachine", "Rekenmachine van merk ..", 8.55, 10, false, "Aalst", "Hogent", LagereSchool, Kaarten);
                Product dobbelsteenschatkist = new Product("dobbelsteen.jpg", 6, "Dobbelsteen schatkist", "koffertje met verschillende soorten dobbelstenen: blanco, met cijfers, ..", 35, 1, true, "GLEDE 1.011", "Hogent", Kleuters, Tellen);
                Product blancodraaischijf = new Product("blanco_draaischijf.PNG", 7, "Blanco shijf", "Met verschillende blanco shijven in hard papier", 31.45, 1, true, "GLEDE 1.011", "HoGent", Kleuters, Kansen);
                Product spinners_klass_ass = new Product("Magnspinner.jpg", 8, "Magnetische spinner", "Magnetische spinners in de vorm van een pijl, een vinger en een potlood", 19.2, 1, true, "GLEDE 1.011", "Hogent", Kleuters , Behendigheid);
                


                context.Producten.Add(landkaart);
                context.Producten.Add(rekenmachine);
                context.Producten.Add(dobbelsteenschatkist);
                context.Producten.Add(blancodraaischijf);
                context.Producten.Add(spinners_klass_ass);
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