using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZK.SchoolManagerPro.Model;
using ZK.SchoolManagerPro.WebPoint.Controllers;

namespace ZK.SchoolManagerPro.WebPoint.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            User urModel = new User();
            urModel.Name = "jkee";
            urModel.Age = 22;

            HomeController homeController = new HomeController();
            string rltStr= homeController.AddUser(urModel).Content;

            Console.WriteLine(rltStr);
            Assert.AreEqual(rltStr,"1");

        }
    }
}
