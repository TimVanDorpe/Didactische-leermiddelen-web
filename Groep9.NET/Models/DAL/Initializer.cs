using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.Entity;
using System.Linq;
using Groep9.NET.Models.Domein;
using System.Web;
using Groep9.NET.Models.Domein;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace Groep9.NET.Models.DAL
{
    public class Initializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
          
            try
            {
                Doelgroep kleuters = new Doelgroep { Naam = "Kleuters" };
                Doelgroep lagereSchool = new Doelgroep { Naam = "Lagere School" };//manier 1

                Leergebied kaarten = new Leergebied("Kaartprojectie");//manier 2
                Leergebied kansen = new Leergebied("Kansberekening");
                Leergebied tellen = new Leergebied("Tellen");
                Leergebied behendigheid = new Leergebied("Behendigheid"); // 2 vss manieren om dit te proberen doen werken, geen van beide die dus werkt..

                context.Doelgroepen.Add(kleuters);
                context.Doelgroepen.Add(lagereSchool);

                context.Leergebieden.Add(kaarten);
                context.Leergebieden.Add(kansen);
                context.Leergebieden.Add(tellen);
                context.Leergebieden.Add(behendigheid);
                context.SaveChanges();

                Product landkaart = new Product("landkaart.jpg", 4, "Landkaart", "Map van België", 8.55, 10, false, "Aalst", "Hogent", lagereSchool, kaarten);
                Product rekenmachine = new Product("rekenmachine.jpg", 5, "Rekenmachine", "Rekenmachine van merk ..", 8.55, 10, false, "Aalst", "Hogent", lagereSchool, kaarten);
                Product dobbelsteenschatkist = new Product("dobbelsteen.jpg", 6, "Dobbelsteen schatkist", "koffertje met verschillende soorten dobbelstenen: blanco, met cijfers, ..", 35, 1, true, "GLEDE 1.011", "Hogent", kleuters, tellen);
                Product blancodraaischijf = new Product("blanco_draaischijf.PNG", 7, "Blanco shijf", "Met verschillende blanco shijven in hard papier", 31.45, 1, true, "GLEDE 1.011", "HoGent", kleuters, kansen);
                Product spinnersKlassAss = new Product("Magnspinner.jpg", 8, "Magnetische spinner", "Magnetische spinners in de vorm van een pijl, een vinger en een potlood", 19.2, 1, true, "GLEDE 1.011", "Hogent", kleuters , behendigheid);
                
                context.Producten.Add(landkaart);
                context.Producten.Add(rekenmachine);
                context.Producten.Add(dobbelsteenschatkist);
                context.Producten.Add(blancodraaischijf);
                context.Producten.Add(spinnersKlassAss);
                context.SaveChanges();

                //InitializeIdentity();


            }
            catch (DbEntityValidationException e)
            {
                string s = "Fout creatie database ";
                foreach (var eve in e.EntityValidationErrors)
                {
                    s +=$"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.GetValidationResult()}\" has the following validation errors:";
                    s = eve.ValidationErrors.Aggregate(s, (current, ve) => $"{current}- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                }
                throw new Exception(s);
            }
        }


        private void InitializeIdentity()
        {


            

            /*
            System.Web.Security.Roles.CreateRole("docenten");
            System.Web.Security.Roles.CreateRole("studenten");
            var docent = new ApplicationUser { UserName = "docent@hogent.be", Email = "docent@hogent.be" };
            */

            /*
            System.Web.Security.Roles.AddUserToRole(docent, "docenten");



            Microsoft.AspNet.Identity.UserManager.CreateAsync(user, model.Password);
            if (result.Succeeded) {
                await UserManager.AddToRoleAsync(user.Id, "student");
                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                return RedirectToAction("Index", "Home");
            }
            AddErrors(result);

            */


        }


        //System.Web.Security.Roles.AddUserToRole(user, "docent");


        /*
        CreateUser("admin@hogent.be", "P@ssword1"); //Create user Admin
        CreateUser("student@hogent.be", "P@ssword1");  //Create User Student
        */
    }

        
    }
