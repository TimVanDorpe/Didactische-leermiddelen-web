using Groep9.NET.Models.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace Groep9.NET.Models
{
    public class Initializer : System.Data.Entity.DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            try
            {


                Product testproduct = new Product();

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