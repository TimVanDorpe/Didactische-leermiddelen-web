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
            ApplicationDbContext c = context;
            // InitializeIdentity();

            InitializeIdentityAndRoles(c);
            base.Seed(context);
        }

        private void InitializeIdentityAndRoles(ApplicationDbContext c)
        {
            CreateUserAndRoles(c, "personeel@hogent.be", "password1", "personeel");

            CreateUserAndRoles(c, "student@hogent.be", "password1", "studenten");

        }


        private void CreateUserAndRoles(ApplicationDbContext c,string email, string password, string roleName)
        {
            //Create user
            ApplicationUser user = userManager.FindByName(email);
            if (user == null)
            {

                if (roleName.Equals("personeel"))
                {
                    user = new ApplicationUser { UserName = email, Email = email, LockoutEnabled = false};
                    c.Users.Add(user);
                }
                else
                {
                    user = new ApplicationUser {  UserName = email, Email = email, LockoutEnabled = false };
                    c.Users.Add(user);
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