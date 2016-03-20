using System;
using Groep9.NET.Models.Domein;
using Groep9.NET.Tests.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Groep9.NET.Tests.Models.Domein {
    [TestClass]
    public class ReservatieTest {

        DummyContext context = new DummyContext();

        [TestInitialize]
        public void Init() {
            context = new DummyContext();
        }

        
        [TestMethod]
        public void ReservatieConstructorTest()
        {
            Reservatie r = new Reservatie(context.P1ZonderReservatiesOfBlokkeringen, 2, context.Student, new DateTime(2016,7,8,0,0,0));
  
            Assert.AreEqual(context.P1ZonderReservatiesOfBlokkeringen, r.Product);
            Assert.AreEqual(2, r.Aantal);
            Assert.AreEqual(context.Student, r.Gebruiker);
            Assert.AreEqual(new DateTime(2016,7,4,8,0,0), r.StartDatum);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ReserverenAlsPersoneelslid()
        {
            Reservatie r = new Reservatie(context.P1ZonderReservatiesOfBlokkeringen, 2, context.Personeelslid, new DateTime(2016, 7, 8, 0, 0, 0));

        }



    }
}
