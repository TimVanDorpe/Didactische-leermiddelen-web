using System;
using System.Data.Entity.Validation;

namespace Groep9.NET.Models.DAL
{
    public class Initializer : System.Data.Entity.DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            try
            {


                Product testproduct = new Product(1,"Testprod", "Dit is een testproduct");
                context.Producten.Add(testproduct);
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