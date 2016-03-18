using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

        //[TestMethod]
        //public void BerekenWeekReturntCorrecteWeekVoorWeek1()
        //{
        //    string datum = "01/03/2017";
        //    Assert.AreEqual(1,context.P1.BerekenWeek(datum));
        //}
        //[TestMethod]
        //public void BerekenWeekReturntCorrecteWeekVoorWeek52() {
        //    string datum = "12/31/2017";
        //    Assert.AreEqual(52, context.P1.BerekenWeek(datum));
        //}


    }
}