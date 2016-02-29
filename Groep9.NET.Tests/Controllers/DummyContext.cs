using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Groep9.NET.Models.Domein;

namespace Groep9.NET.Tests.Models
{
    /// <summary>
    /// Summary description for DummyContext
    /// </summary>
    [TestClass]
    public class DummyContext
    {

        public IQueryable<Product> ProductenLijst { get; private set; }
        public Product VoorbeeldProduct { get; private set; }
        public Product VoorbeeldProduct2 { get;  private set; }
        public Product VoorbeeldProduct3 { get; private set; }

      


        public DummyContext()
        {
            List<Doelgroep> doelgroepen =  new List<Doelgroep>();
            List<Leergebied> leergebieden = new List<Leergebied>();
            Leergebied x = new Leergebied("Tellen");
            Doelgroep y = new Doelgroep("Kleuters");

            doelgroepen.Add(y);
            leergebieden.Add(x);


            VoorbeeldProduct = new Product("",1, "A","TestProd", 2.1, 1, true, "hier", "B", doelgroepen, leergebieden);
            VoorbeeldProduct2 = new Product("",2, "B", "TestProd2", 5.8, 1, true, "hier", "B", doelgroepen, leergebieden);
            VoorbeeldProduct3 = new Product("",3, "C", "TestProd3", 2.1, 1, true, "hier", "B", doelgroepen, leergebieden);
            ProductenLijst =
                (new Product[] { VoorbeeldProduct, VoorbeeldProduct2, VoorbeeldProduct3 }).ToList().AsQueryable();
            

        }

        public Product GetProduct(int id)
        {
            return ProductenLijst.FirstOrDefault(p=> p.ProductId== id);
        }

        

    }
}
