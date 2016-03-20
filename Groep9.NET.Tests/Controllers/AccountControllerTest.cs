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
    public class AccountControllerTest
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        DummyContext context;
        [TestInitialize]
        public void SetUpContext()
        {
            //_signInManager = new ApplicationSignInManager();
            //_userManager = new ApplicationUserManager();
            context = new DummyContext();
        }




        [TestMethod]
        public void Login()
        {
            // Arrange
            AccountController controller = new AccountController(_userManager, _signInManager);

            // Act
            ViewResult result = controller.Login("www.db.com") as ViewResult;


            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void LogOut()
        {
            // Arrange
            AccountController controller = new AccountController(_userManager, _signInManager);

            // Act
            ViewResult result = controller.LogOut() as ViewResult;


            // Assert
            Assert.AreEqual(result, "Login");
        }
    }
}