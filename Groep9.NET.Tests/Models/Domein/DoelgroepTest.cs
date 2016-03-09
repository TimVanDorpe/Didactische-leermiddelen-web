using System;
using Groep9.NET.Models.Domein;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Groep9.NET.Tests.Models.Domein {
    [TestClass]
    public class DoelgroepTest {
        DummyContext context;

        [TestInitialize]
        public void Initialize() {
            context = new DummyContext();
        }
        [TestMethod]
        public void RegistreerProductRegistreertDGProduct() {
            Doelgroep dg = new Doelgroep();
            dg.RegistreerProduct(new Product());
            Assert.AreEqual(1, dg.Producten.Count);
        }
    }
}
