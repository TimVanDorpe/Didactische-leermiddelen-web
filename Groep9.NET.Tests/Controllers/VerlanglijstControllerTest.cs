using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Groep9.NET.Controllers;
using Groep9.NET.Models.Domein;
using Groep9.NET.Tests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Groep9.NET.Tests.Controllers {
    [TestClass]
    public class VerlanglijstControllerTest {
        private VerlanglijstController vController;
        private Gebruiker g;
        private Mock<IProductRepository> mockpr;
        private Mock<ILeergebiedRepository> mocklr;
        private Mock<IDoelgroepRepository> mockdr;
        private Mock<IGebruikerRepository> mockgr;
        private DummyContext context;

        [TestInitialize]
        public void Init()
        {
            context = new DummyContext();
            mockpr = new Mock<IProductRepository>();
            mockdr = new Mock<IDoelgroepRepository>();
            mocklr = new Mock<ILeergebiedRepository>();
            mockgr = new Mock<IGebruikerRepository>();
            mockpr.Setup(p => p.VindAlleProducten()).Returns(context.Producten.AsQueryable());
            mockpr.Setup(p => p.FindByProductNummer(1)).Returns(context.P1);
        //    vController = new VerlanglijstController(mockpr.Object, mockdr.Object, mocklr.Object, mockgr.Object);
        }

        [TestMethod]
        public void IndexReturnsVerlanglijstVanGebruiker() {
            g = context.Gebruiker;
            g.VerlangLijst.Add(context.P1);
            g.VerlangLijst.Add(context.P2);
            ViewResult result = vController.Index(g) as ViewResult;
            List<Product> producten = (result.Model as IEnumerable<Product>).ToList();
            Assert.IsNotNull(result);
            Assert.AreEqual(g.VerlangLijst.Count, producten.Count);
        }
        [TestMethod]
        public void IndexReturnsLegeVerlanglijstIndienLeeg() {
            g = context.Gebruiker;
            ViewResult result = vController.Index(g) as ViewResult;
            List<Product> producten = (result.Model as IEnumerable<Product>).ToList();
            Assert.IsNotNull(result);
            Assert.AreEqual(0, producten.Count);
        }
        
        [TestMethod]
        public void RemoveWillRedirectToIndex() {
            g = context.Gebruiker;
            RedirectToRouteResult result = vController.RemoveFromVerlanglijst(1,g) as RedirectToRouteResult;
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void RemoveWillRemoveFromVerlanglijst() {
            g = context.Gebruiker;
            g.VerlangLijst.Add(context.P1);
            RedirectToRouteResult result = vController.RemoveFromVerlanglijst(1, g) as RedirectToRouteResult;
            Assert.AreEqual(0, g.VerlangLijst.Count);
            mockpr.Verify(p => p.FindByProductNummer(1), Times.Once());
        }

        [TestMethod]
        public void DetailsToontDetails() {
            ViewResult result = vController.Details(1) as ViewResult;
            Product product = result.Model as Product;
            Assert.AreEqual(context.P1.Omschrijving, product.Omschrijving);
        }
       
    }
}
