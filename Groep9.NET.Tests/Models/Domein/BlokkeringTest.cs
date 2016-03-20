using System;
using Groep9.NET.Models.Domein;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Groep9.NET.Tests.Models.Domein {
    [TestClass]
    public class BlokkeringTest {

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void TestBlokkeringConstructorArgumentExeption() {
            int aantal = 1;
            Product product = new Product();
            Gebruiker student = new Student();
            DateTime datum = DateTime.Now;
            Blokkering x = new Blokkering(product, aantal, student, datum);

        }
    }
}
