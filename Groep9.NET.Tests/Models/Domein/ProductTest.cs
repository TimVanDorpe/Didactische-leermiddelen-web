using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Groep9.NET.Helpers;

namespace Groep9.NET.Tests.Models.Domein
{
    [TestClass]
    public class ProductTest
    {
        private DummyContext context;

        [TestInitialize]
        public void Initialize()
        {
            context = new DummyContext();
        }

        /* VOOR IN HELPER TEST

        [TestMethod]
        public void BerekenWeekReturntCorrecteWeekVoorWeek1()
        {
            string datum = "01/03/2017";
            DateTime date = Helper.ZetDatumOm(datum);
            Assert.AreEqual(1,Helper.BerekenWeek(date));
        }
        [TestMethod]
        public void BerekenWeekReturntCorrecteWeekVoorWeek52() {
            string datum = "12/31/2017";
            DateTime date = Helper.ZetDatumOm(datum);
            Assert.AreEqual(52, Helper.BerekenWeek(date));
        }
        */

    }
}