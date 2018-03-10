using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdneomTST;
using AdneomTST.Controllers;

namespace AdneomTST.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Check_IndexPage()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}
