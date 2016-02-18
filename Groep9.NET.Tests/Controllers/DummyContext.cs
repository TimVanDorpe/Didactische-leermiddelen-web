using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Groep9.NET.Tests.Models
{
    /// <summary>
    /// Summary description for DummyContext
    /// </summary>
    [TestClass]
    public class DummyContext
    {
        public Product VoorbeeldProduct { get; set; }
        public DummyContext()
        {
            VoorbeeldProduct = new Product("./Content/images/dobbelsteen.PNG", 1, "A", "TestProd", 2.1, 1, true, "hier", "B", "C", "D");
        }
           
    }
}
