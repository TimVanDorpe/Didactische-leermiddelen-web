using System;
using Groep9.NET.Tests.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Groep9.NET.Tests.Models.Domein {
    [TestClass]
    public class FirmaTest {

        DummyContext context = new DummyContext();

        [TestInitialize]
        public void init()
        {
            context = new DummyContext();
        }


        [TestMethod]
        public void FirmaTest1() {

            Firma f = new Firma("hogent", "hogent.be", "ho@hogent.be");
            f.FirmaId = 1;

            Assert.AreEqual("hogent", f.Naam);
            Assert.AreEqual("hogent.be", f.FirmaUrl);
            Assert.AreEqual("ho@hogent.be", f.Contactemail);
            Assert.AreEqual(1, f.FirmaId);


        }
    }
}
