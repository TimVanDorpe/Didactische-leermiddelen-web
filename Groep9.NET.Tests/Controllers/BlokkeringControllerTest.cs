using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Groep9.NET;
using Groep9.NET.Controllers;
using Groep9.NET.Models.Domein;
using Groep9.NET.Models.DAL;
using Moq;

namespace Groep9.NET.Tests.Controllers
{
    [TestClass]
    public class BlokkeringControllerTest
    {
        private Mock<IGebruikerRepository> mockgr;
        DummyContext context;
        [TestInitialize]
        public void SetUpContext()
        {
            mockgr = new Mock<IGebruikerRepository>();
            context = new DummyContext();
        }




        [TestMethod]
        public void Index()
        {
            // Arrange
            BlokkeringController controller = new BlokkeringController(mockgr.Object);

            // Act
            ViewResult result = controller.Index(context.Personeelslid) as ViewResult;


            // Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void RemoveFromBlokkeringsLijst()
        {
            // Arrange
            BlokkeringController controller = new BlokkeringController(mockgr.Object);

            // Act

            ViewResult result = controller.RemoveFromBlokkeringLijst(0, context.Personeelslid) as ViewResult;


            // Assert
            Assert.AreEqual("Index", result);
        }
        [TestMethod]
        public void BlokkeringControllerConstructor()
        {
      
        }
    }
}
