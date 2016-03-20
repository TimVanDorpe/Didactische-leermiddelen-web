using System;
using Groep9.NET.Models.Domein;
using Groep9.NET.Tests.Controllers;
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

        [TestMethod]
        public void TestDoelgroepNaam()
        {
            Doelgroep dg = new Doelgroep("dg");
            Assert.AreEqual("dg", dg.Naam);
        }

        [TestMethod]
        public void TestDoelgroepId()
        {
            Doelgroep dg = new Doelgroep();
            dg.DoelgroepId = 1;
            Assert.AreEqual(1, dg.DoelgroepId);
        }
    }
}
