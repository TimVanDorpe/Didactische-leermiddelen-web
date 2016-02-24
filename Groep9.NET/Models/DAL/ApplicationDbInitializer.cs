using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Groep9.NET.Models.Domein;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace Groep9.NET.Models.DAL
{
    public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;
        protected override void Seed(ApplicationDbContext context)
        {
            userManager =
              HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

            roleManager =
               HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();

            // InitializeIdentity();

            InitializeIdentityAndRoles();
            base.Seed(context);
        }

        private void InitializeIdentityAndRoles()
        {
            CreateUserAndRoles("personeel@hogent.be", "password1", "personeel");

            CreateUserAndRoles("student@hogent.be", "password1", "studenten");

        }


        private void CreateUserAndRoles(string email, string password, string roleName)
        {
            //Create user
            Gebruiker user = userManager.FindByName(email);
            if (user == null)
            {

                if (roleName.Equals("personeel"))
                {
                    user = new Personeelslid { UserName = email, Email = email, LockoutEnabled = false};
                }
                else
                {
                    user = new Student { UserName = email, Email = email, LockoutEnabled = false };
                }
                IdentityResult result = userManager.Create(user, password);
                if (!result.Succeeded)
                    throw new ApplicationException(result.Errors.ToString());
            }

            //Create roles
            IdentityRole role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                IdentityResult result = roleManager.Create(role);
                if (!result.Succeeded)
                    throw new ApplicationException(result.Errors.ToString());
            }

            //Associate user with role
            IList<string> rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                IdentityResult result = userManager.AddToRole(user.Id, roleName);
                if (!result.Succeeded)
                    throw new ApplicationException(result.Errors.ToString());
            }
        }
    }
}