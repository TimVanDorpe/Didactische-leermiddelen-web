using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Groep9.NET.Models.Domein;
using Groep9.NET.Tests.Controllers;

namespace Groep9.NET.Tests.Models.Domein {
    [TestClass]
    public class ReservatieAbstrTest {
        DateTime today;
        DateTime yesterday;
        int aantal;
        Product p;
        Gebruiker Tim;
        DummyContext context;


        [TestInitialize]
        public void Initialize()
        {
            today = System.DateTime.Now;
            yesterday = today.AddDays(-1);
            aantal = -1;
            p = new Product();
            Tim = new Student();
            context = new DummyContext();

        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void ReservatieAbstrDatumConstructorException()
        {
            ReservatieAbstr x = new Reservatie(p, 5, Tim, yesterday);

        }


        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void ReservatieAbstrAantalConstructorException()
        {
            ReservatieAbstr x = new Reservatie(p, aantal, Tim, today);

        }


        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void ReservatieAbstrProductAantalConstructorException()
        {
            p = context.P1ZonderReservatiesOfBlokkeringen;
            p.Aantal = -1;
            ReservatieAbstr x = new Reservatie(p, 5, Tim, today);

        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void ReservatieAbstrAantalSetStartDatumReservatieWeekException()
        {
            ReservatieAbstr x = new Reservatie(p, 5, Tim, today);
            x.SetStartDatumReservatieWeek(yesterday);
        }


        [TestMethod]
        public void AddWeekdagTest()
        {
            ReservatieAbstr x = new Blokkering();
            x.AddWeekdag(true, true, false, false, false);
            Assert.AreEqual(2, x.Weekdagen.Count);
        }
    }
}
