using System;
using System.Data.Entity.Validation;
using System.Data.Entity;

namespace Groep9.NET.Models.DAL
{
    public class Initializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            try
            {


                Product testproduct = new Product("dobbelsteen.png", 1, "Testprod", "Dit is een testproduct", 12.95, 3, true, "Gent", "Hogent", "Informatica", ".net");
                Product testproduct2 = new Product("dobbelsteen.png", 2, "Testprod2", "Dit is een testproduct", 7.85, 9, false, "Aalst", "Hogent", "Landmeetkunde", "Kaartprojectie");
                Product testproduct3 = new Product("dobbelsteen.png", 3, "Test product 3", "een testproduct", 8.55, 10, false, "Aalst", "Hogent", "Landmeetkunde", "Kaartprojectie");
                Product testproduct4 = new Product("dobbelsteen.png", 4, "Landkaart", "Map van België", 8.55, 10, false, "Aalst", "Hogent", "Landmeetkunde", "Kaartprojectie");
                Product testproduct5 = new Product("dobbelsteen.png", 5, "Rekenmachine", "Rekenmachine van merk ..", 8.55, 10, false, "Aalst", "Hogent", "Landmeetkunde", "Kaartprojectie");
                Product dobbelsteenschatkist = new Product("dobbelsteen.png", 6, "dobbelsteen-schatkist-162delig", "koffertje met verschillende soorten dobbelstenen: blanco, met cijfers, ..", 35, 1, true, "GLEDE 1.011", "Hogent", "Kleuters", "Tellen");

                context.Producten.Add(testproduct);
                context.Producten.Add(testproduct2);
                context.Producten.Add(testproduct3);
                context.Producten.Add(testproduct4);
                context.Producten.Add(testproduct5);
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