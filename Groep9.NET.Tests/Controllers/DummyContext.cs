using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

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
            //VoorbeeldProduct = new Product("",1, "A","TestProd", 2.1, 1, true, "hier", "B", "C", "D");
            //VoorbeeldProduct2 = new Product("",2, "B", "TestProd2", 5.8, 1, true, "hier", "B", "C", "D");
            //VoorbeeldProduct3 = new Product("",3, "C", "TestProd3", 2.1, 1, true, "hier", "B", "C", "D");
            //ProductenLijst =
            //     (new Product[] { VoorbeeldProduct, VoorbeeldProduct2, VoorbeeldProduct3 }).ToList().AsQueryable();


        }

        public Product GetProduct(int id)
        {
            return ProductenLijst.FirstOrDefault(p=> p.ProductNummer== id);
        }

    }
}
