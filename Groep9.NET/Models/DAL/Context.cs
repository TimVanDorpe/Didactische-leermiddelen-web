
using Groep9.NET.Models.Domein;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Groep9.NET.Models.DAL
{
    public class Context : DbContext
    {

        public Context(): base("groep9")
        { }

        public DbSet<Product> Producten { get; set; }
        public DbSet<Leergebied> Leergebieden { get; set; }
        public DbSet<Doelgroep> Doelgroepen { get; set; }
        public DbSet<Gebruiker> Gebruikers { get; set; }

      

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());

            //hotfix
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }
        public static Context Create()
        {
            return DependencyResolver.Current.GetService<Context>();
        }


    }
}