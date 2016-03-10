using System;
using Groep9.NET.Models.Domein;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Groep9.NET.Tests.Models.Domein {
    [TestClass]
    public class LeergebiedTest {
        DummyContext context;

        [TestInitialize]
        public void Initialize() {
            context = new DummyContext();
        }
        [TestMethod]
        public void RegistreerProductRegistreertLGProduct()
        {
            Leergebied lg = new Leergebied();
            lg.RegistreerLeergebied(new Product());

            Assert.AreEqual(1, lg.Producten.Count);
        }

       
    }
}
