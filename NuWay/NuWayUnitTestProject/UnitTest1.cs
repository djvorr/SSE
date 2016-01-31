using System;
using NuWay;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;

namespace NuWayUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            NuWayOrderForm form = new NuWayOrderForm();
            form.Show();
            TextBox tb = form.getTextBox("tbTotal");
            String zero = "0.00";
            Assert.AreEqual(tb.Text, zero, "Total not zeroed");
        }
    }
}
