using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Groep9.NET.Models.DAL
{
    public class Context : DbContext
    {

        public Context(): base("groep9")
        { }

        public DbSet<Product> Producten { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }
        public static Context Create()
        {
            return DependencyResolver.Current.GetService<Context>();
        }
    }
}