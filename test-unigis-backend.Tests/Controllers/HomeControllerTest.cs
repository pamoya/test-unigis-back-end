using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using test_unigis_backend;
using test_unigis_backend.Controllers;

namespace test_unigis_backend.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Disponer
            HomeController controller = new HomeController();

            // Actuar
            ViewResult result = controller.Index() as ViewResult;

            // Declarar
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
