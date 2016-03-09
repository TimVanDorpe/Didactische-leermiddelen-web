using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Groep9.NET.Controllers;
using Groep9.NET.Models.Domein;
using System;
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

        private Gebruiker g;

        private IQueryable<Product> ProductenLijst;

        [TestInitialize]
        public void SetUpContext() {
            
            mockpr = new Mock<IProductRepository>();
            mockdr = new Mock<IDoelgroepRepository>();
            mocklr = new Mock<ILeergebiedRepository>();
            mockgr = new Mock<IGebruikerRepository>();
            product1 = context.P1;
            product2 = context.P2;
            product3 = context.P3;
            //model = new ProductViewModel();
            ProductenLijst = context.producten.AsQueryable();

            mockpr.Setup(p => p.VindAlleProducten()).Returns(ProductenLijst);
            mockpr.Setup(p => p.FindByProductNummer(1)).Returns(product1);

            g = context.Gebruiker;

            cc = new CatalogusController(mockpr.Object, mockdr.Object, mocklr.Object, mockgr.Object);
        }


        [TestMethod]
        public void IndexReturnsAlleProducten() {
            //Act
            ViewResult result = cc.Index(g) as ViewResult;
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


        /*
        private SelectList GetDoelgroepSelectList() {
            return new SelectList(doelgroepRepository.VindAlleDoelgroepen().Select(p => p.Naam));

        }
        private SelectList GetLeergebiedSelectList() {
            return new SelectList(leergebiedRepository.VindAlleLeergebieden().Select(p => p.Naam));

        }
        public ActionResult Details(int id) {
            Product product = productRepository.FindByProductNummer(id);
            return View(product);
        }

        public void FillDropDownList() {

            ViewBag.leergebied = GetLeergebiedSelectList();
            ViewBag.doelgroep = GetDoelgroepSelectList();

        }
        public Boolean CheckVerlanglijst(int id, Gebruiker gebruiker) {
            Product product = productRepository.FindByProductNummer(id);
            if (gebruiker.VerlangLijst.Contains(product)) {
                return true;
            }
            else {
                return false;
            }
        }


        public ActionResult AddToVerlanglijst(int id, Gebruiker gebruiker) {
            Product product = productRepository.FindByProductNummer(id);
            gebruiker.VoegProductAanVerlanglijstToe(product);
            gebruikerRepository.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AddOfVerwijderVerlanglijst(int id, Gebruiker gebruiker) {
            if (!CheckVerlanglijst(id, gebruiker)) {
                Product product = productRepository.FindByProductNummer(id);
                gebruiker.VoegProductAanVerlanglijstToe(product);
                gebruikerRepository.SaveChanges();

            }
            else {
                Product product = productRepository.FindByProductNummer(id);
                gebruiker.VerwijderProductUitVerlanglijst(product);
                gebruikerRepository.SaveChanges();
            }
            // Gebruiker currentUser = gebruikerRepository.FindByEmail(User.Identity.Name);

            return RedirectToAction("Index");
        }
        */
    }
}
