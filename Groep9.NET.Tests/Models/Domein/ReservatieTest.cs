using System;
using Groep9.NET.Models.Domein;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Groep9.NET.Tests.Models.Domein {
    [TestClass]
    public class ReservatieTest {

        private Reservatie r;


        [TestInitialize]
        public void Init() {
            r = new Reservatie();
        }

        /* TESTEN MOETEN HERSCHREVEN WORDEN
        [TestMethod]
        public void BerekenStartDatumRetourneertCorrecteDatumMaandag() {
            DateTime expectedDateTime = new DateTime(2016, 3, 14, 8, 0, 0, 0);
            Assert.AreEqual(expectedDateTime, r.SetStartDatumReservatieWeek("", new DateTime(2016, 3, 8, 0, 0, 0, 0)));
        }
        [TestMethod]
        public void BerekenStartDatumRetourneertCorrecteDatumDonderdag() {
            DateTime expectedDateTime = new DateTime(2016, 3, 14, 8, 0, 0, 0);
            Assert.AreEqual(expectedDateTime, r.BerekenStartDatumReservatieWeek("", new DateTime(2016, 3, 10, 0, 0, 0, 0)));
        }
        [TestMethod]
        public void BerekenStartDatumRetourneertCorrecteDatumVrijdagVoor17Uur() {
            DateTime expectedDateTime = new DateTime(2016, 3, 14, 8, 0, 0, 0);
            Assert.AreEqual(expectedDateTime, r.BerekenStartDatumReservatieWeek("", new DateTime(2016, 3, 11, 0, 0, 0, 0)));
        }
        [TestMethod]
        public void BerekenStartDatumRetourneertCorrecteDatumWeekend() {
            DateTime expectedDateTime = new DateTime(2016, 3, 21, 8, 0, 0, 0);
            Assert.AreEqual(expectedDateTime, r.BerekenStartDatumReservatieWeek("", new DateTime(2016, 3, 12, 0, 0, 0, 0)));
        }

        [TestMethod]
        public void BerekenEindDatumRetourneertCorrecteDatum() {
            DateTime expectedDateTime = new DateTime(2016, 3, 18, 17, 0, 0, 0);
            Assert.AreEqual(expectedDateTime, r.BerekenEindDatumReservatieWeek("", new DateTime(2016, 3, 8, 0, 0, 0, 0)));
        }

        */
    }
}
