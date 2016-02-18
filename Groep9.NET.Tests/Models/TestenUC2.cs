using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Groep9.NET.Models.DAL;

namespace Groep9.NET.Tests.Models
{
    /// <summary>
    ///Al de testen voor UC2
    /// </summary>
    [TestClass]
    public class TestenUC2
    {

        private Context context;
        public TestenUC2()
        {
            
        }
        public void Initialize()
        {
            
        }


        [TestMethod]
        public void ZoekenMetResultaat()
        {

              //ProductRepository pr = new ProductRepository(context);
            //Product VoorbeeldProduct = new Product(1, "A", "TestProd", 2.1, 1, true, "hier", "B", "C", "D");
            //Assert.AreEqual(pr.Zoeken("A"), VoorbeeldProduct);
        }
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void ZoekenZonderResultaat()
        {
            //
            // TODO: Add test logic here
            //
        }
        [TestMethod]
        public void GeavenceerdZoeken()
        {
            //
            // TODO: Add test logic here
            //
        }
        [TestMethod]
        public void ToonCatalogus()
        {
            //
            // TODO: Add test logic here
            //
        }
       
    }
}
