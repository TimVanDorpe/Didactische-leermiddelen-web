using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Groep9.NET.Models.Domein;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Groep9.NET.Models.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        //public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
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