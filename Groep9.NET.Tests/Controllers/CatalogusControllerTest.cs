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
        private Product VoorbeeldProduct;
        private Mock<IProductRepository> mockProductenRepository;
        private ProductViewModel model;
        public CatalogusControllerTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        [TestInitialize]
        public void SetUpContext()
        {
            DummyContext context = new DummyContext();
            mockProductenRepository = new Mock<IProductRepository>();
            VoorbeeldProduct = context.VoorbeeldProduct;
            CC = new CatalogusController(mockProductenRepository.Object);
            model = new ProductViewModel(VoorbeeldProduct);
          
           
        }


        [TestMethod]
        public void TestMethod1()
        {
            //ViewResult result = CC.Index(VoorbeeldProduct) as ViewResult;
        }
    }
}
