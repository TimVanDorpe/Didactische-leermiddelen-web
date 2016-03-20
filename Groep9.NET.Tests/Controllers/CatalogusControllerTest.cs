using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Groep9.NET.Controllers;
using Groep9.NET.Models.Domein;
using System.Linq;
using System.Web.Mvc;
using Groep9.NET.ViewModels;
using Moq;
using Groep9.NET.Tests.Models;

namespace Groep9.NET.Tests.Controllers {
    /// <summary>
    /// Summary description for CatalogusControllerTest
    /// </summary>
    [TestClass]
    public class CatalogusControllerTest {

        private CatalogusController cc;
        private Mock<IProductRepository> mockpr;
        private Mock<ILeergebiedRepository> mocklr;
        private Mock<IDoelgroepRepository> mockdr;
        private Mock<IGebruikerRepository> mockgr;

        //private ProductViewModel model;

        private DummyContext context = new DummyContext();

        private Product product1;
        private Product product2;
        private Product product3;

        private Gebruiker gebruiker;

        private IQueryable<Product> ProductenLijst;

        [TestInitialize]
        public void SetUpContext() {
            
            mockpr = new Mock<IProductRepository>();
            mockdr = new Mock<IDoelgroepRepository>();
            mocklr = new Mock<ILeergebiedRepository>();
            mockgr = new Mock<IGebruikerRepository>();
            product1 = context.P1ZonderReservatiesOfBlokkeringen;
            product2 = context.P2ZonderReservatiesOfBlokkeringen;
            product3 = context.P3ZonderReservatiesOfBlokkeringen;
            //model = new ProductViewModel();
            ProductenLijst = context.Producten.AsQueryable();

            mockpr.Setup(p => p.VindAlleProducten()).Returns(ProductenLijst);
            mockpr.Setup(p => p.FindByProductNummer(1)).Returns(product1);

            gebruiker = context.Gebruiker;

            cc = new CatalogusController(mockpr.Object, mockdr.Object, mocklr.Object, mockgr.Object);
        }


        [TestMethod]
        public void IndexReturnsAlleProducten() {
            //Act
            ViewResult result = cc.Index(gebruiker) as ViewResult;
            List<Product> producten = (result.Model as IEnumerable<Product>).ToList();


            //Assert
            Assert.AreEqual(3, producten.Count);
            Assert.AreEqual(1, producten[0].ProductId);
            Assert.AreEqual("B", producten[1].Naam);
            Assert.AreEqual("C", producten[2].Naam);

        }

        [TestMethod]
        public void DetailsReturnsDetails() {
            ViewResult result = cc.Details(1) as ViewResult;
            Product product = result.Model as Product;

            //Assert
            Assert.AreEqual(product1.Omschrijving, product.Omschrijving);
        }
        

        [TestMethod]
        public void GetdoelgroepSelectListReturnsDoelgroepSelectList()
        {
            
        }


        
    }
}
