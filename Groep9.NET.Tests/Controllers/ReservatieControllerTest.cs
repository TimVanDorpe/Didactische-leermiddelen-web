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
    public class ReservatieControllerTest {
        private ReservatieController rController;
        private Gebruiker g;
        private Mock<IProductRepository> mockpr;
        private Mock<ILeergebiedRepository> mocklr;
        private Mock<IDoelgroepRepository> mockdr;
        private Mock<IGebruikerRepository> mockgr;
        private DummyContext context;

        [TestInitialize]
        public void Init() {
            context = new DummyContext();
            mockpr = new Mock<IProductRepository>();
            mockdr = new Mock<IDoelgroepRepository>();
            mocklr = new Mock<ILeergebiedRepository>();
            mockgr = new Mock<IGebruikerRepository>();
            mockpr.Setup(p => p.VindAlleProducten()).Returns(context.Producten.AsQueryable());
            mockpr.Setup(p => p.FindByProductNummer(1)).Returns(context.P1);
         //   rController = new ReservatieController(mockpr.Object, mockdr.Object, mocklr.Object, mockgr.Object);
        }

        [TestMethod]
        public void IndexReturnsReservaties() {
            g = context.Gebruiker;
            g.VerlangLijst.Add(context.P1);
        //    Reservatie r = new Reservatie(context.P1, 1);
         //   g.ReservatieLijst.Add(r);
            ViewResult result = rController.Index(g) as ViewResult;
            List<Product> producten = (result.Model as IEnumerable<Product>).ToList();
            Assert.IsNotNull(result);
            Assert.AreEqual(g.ReservatieLijst.Count, producten.Count);
        }
        [TestMethod]
        public void IndexReturnsLegeReservatieLijstIndienLeeg() {
            g = context.Gebruiker;
            ViewResult result = rController.Index(g) as ViewResult;
            List<Product> producten = (result.Model as IEnumerable<Product>).ToList();
            Assert.IsNotNull(result);
            Assert.AreEqual(0, producten.Count);
        }
        
    }
}
