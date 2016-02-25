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

namespace Groep9.NET.Tests.Controllers
{
    /// <summary>
    /// Summary description for CatalogusControllerTest
    /// </summary>
    [TestClass]
    public class CatalogusControllerTest
    {

        private CatalogusController CC;
        private Mock<IProductRepository> mockProductenRepository;
        private ProductViewModel model;
        private Mock<ILeergebiedRepository> mocklr;
        private Mock<IDoelgroepRepository> mockdr;
        private Product product1;
        private IQueryable<Product> ProductenLijst;

        [TestInitialize]
        public void SetUpContext()
        {
            DummyContext context = new DummyContext();
            mockProductenRepository = new Mock<IProductRepository>();
            mockdr = new Mock<IDoelgroepRepository>();
            mocklr = new Mock<ILeergebiedRepository>();
            product1 = context.VoorbeeldProduct;
            CC = new CatalogusController(mockProductenRepository.Object , mockdr.Object, mocklr.Object);
            model = new ProductViewModel();
            ProductenLijst = context.ProductenLijst;
        }


        [TestMethod]
        public void IndexReturnsAlleProducten()
        {
            //Act
            ViewResult result = CC.Index("","","") as ViewResult;
            List<Product> producten = (result.Model as IEnumerable<Product>).ToList();
                
                
            //Assert
              Assert.AreEqual(3, producten.Count());
            //     Assert.AreEqual(1, producten[0].ProductId);
            //   Assert.AreEqual(2, producten[1].Naam);
            //   Assert.AreEqual("C", producten[2].Naam);

        }

        [TestMethod]
        public void DetailsReturnsDetails()
        {
           ViewResult result = CC.Details(1) as ViewResult;
             Product product = result.Model as Product;

            //Assert
            Assert.AreEqual(product1.Omschrijving, product.Omschrijving);


        }
    }
}
