using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Groep9.NET.Models.Domein;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Groep9.NET.Models.DAL
{
    public class ApplicationDbContext : IdentityDbContext<Gebruiker>
    {
        public ApplicationDbContext()
            : base("Gebruikers", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        static ApplicationDbContext()
        {
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }
    }
}