using System;
using Groep9.NET.Models.Domein;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Groep9.NET.Tests.Models.Domein {
    [TestClass]
    public class DagTest {
        [TestMethod]
        public void DagTest1() {
            var d = new Dag("Maandag");
            Assert.AreEqual(d.Naam, "Maandag");
        }

        [TestMethod]
        public void DagTest2() {
            var d = new Dag("Maandag");
            d.DagId = 1;
            Assert.AreEqual(1, d.DagId);
        }
    }
}
