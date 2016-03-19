using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Groep9.NET.Tests.Models.Domein {
    [TestClass]
    public class GebruikerTest {
        DummyContext context;

        [TestInitialize]
        public void Initialize() {
            context = new DummyContext();
        }
        [TestMethod]
        public void VoegProductAanVerlanglijstToeVoegtProductToe()
        {
            context.Gebruiker.VoegProductAanVerlanglijstToe(context.P1ZonderReservatiesOfBlokkeringen);
            Assert.AreEqual(1, context.Gebruiker.VerlangLijst.Count);
        }

        [TestMethod]
        public void VerwijderProductUitVerlanglijstVerwijdertProduct()
        {
            context.Gebruiker.VerwijderProductUitVerlanglijst(context.P1ZonderReservatiesOfBlokkeringen);
            Assert.AreEqual(0, context.Gebruiker.VerlangLijst.Count);
        }
    }
}
