using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Groep9.NET.Helpers;

namespace Groep9.NET.Tests.Helpers {
    [TestClass]
    public class HelperTest {

        private DateTime nogGeenVrijdag = new DateTime(2016, 3, 15, 0, 0, 0);
        private DateTime weekend = new DateTime(2016, 3, 19, 0, 0, 0);
        private DateTime volgendeWeek = new DateTime(2016, 3, 22, 0, 0, 0);
        private DateTime binnen2Weken = new DateTime(2016, 3, 30, 0, 0, 0);
        private DateTime binnen3Weken = new DateTime(2016, 4, 8, 0, 0, 0);

        [TestMethod]
        public void BerekenStartDatumReturntCorrecteDatumDezeWeekVoorVrijdag() {
            DateTime expected = new DateTime(2016, 3, 21, 8, 0, 0);
            Assert.AreEqual(expected, Helper.BerekenStartDatumReservatieWeek(nogGeenVrijdag));
        }
        [TestMethod]
        public void BerekenStartDatumReturntCorrecteDatumDezeWeekNaVrijdag() {
            DateTime expected = new DateTime(2016, 3, 28, 8, 0, 0);
            Assert.AreEqual(expected, Helper.BerekenStartDatumReservatieWeek(weekend));
        }
        [TestMethod]
        public void BerekenStartDatumReturntCorrecteDatumVolgendeWeek() {
            DateTime expected = new DateTime(2016, 3, 21, 8, 0, 0);
            Assert.AreEqual(expected, Helper.BerekenStartDatumReservatieWeek(volgendeWeek));
        }
        [TestMethod]
        public void BerekenStartDatumReturntCorrecteDatumBinnen2Weken() {
            DateTime expected = new DateTime(2016, 3, 28, 8, 0, 0);
            Assert.AreEqual(expected, Helper.BerekenStartDatumReservatieWeek(binnen2Weken));
        }
        [TestMethod]
        public void BerekenStartDatumReturntCorrecteDatumBinnen3Weken() {
            DateTime expected = new DateTime(2016, 4, 4, 8, 0, 0);
            Assert.AreEqual(expected, Helper.BerekenStartDatumReservatieWeek(binnen3Weken));
        }
        [TestMethod]
        public void BerekenEindDatumReturntCorrecteEindDatum() {
            DateTime expected = new DateTime(2016, 3, 25, 17, 0, 0);
            Assert.AreEqual(expected, Helper.BerekenEindDatumReservatieWeek(nogGeenVrijdag));
        }
        [TestMethod]
        public void BerekenWeekReturntCorrecteWeek() {
            int expected = 1;
            Assert.AreEqual(expected, Helper.BerekenWeek(new DateTime(2016,1,4,0,0,0)));
        }
        [TestMethod]
        public void ZetDatumOmReturntJuisteDatum() {
            DateTime expected = new DateTime(2016, 3, 25);
            Assert.AreEqual(expected, Helper.ZetDatumOm("25/03/2016"));
        }
        [TestMethod]
        public void ZetDatumOmReturntJuisteDatumIndienNull() {
            DateTime expected = DateTime.Today;
            Assert.AreEqual(expected, Helper.ZetDatumOm(null));
        }


    }
}
