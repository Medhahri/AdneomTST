using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdneomTST;
using AdneomTST.Controllers;
using AdneomTST.Models.Repositories;
using System.Web.Http.Results;
using AdneomTST.Models.ViewModels;
using Moq;
using System.Collections.Generic;


namespace AdneomTST.Tests.Controllers
{
    [TestClass]
    public class CafeControllerTest
    {

        [TestMethod]
        public void Check_PostPCoffee()
        {
            //arrange  
            var item = GetDemoCoffee();

            Mock<ICoffeeRepository> mockRepository = new Mock<ICoffeeRepository>();
            mockRepository.Setup(x => x.Add(item)).Verifiable();

            CafeController controller = controller = new CafeController(mockRepository.Object);
            var result = controller.PostCoffee(item);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<bool>));
        }

        [TestMethod]
        public void Check_GetLastCoffee()
        {
            var item = GetDemoCoffee();

            Mock<ICoffeeRepository> mockRepository = new Mock<ICoffeeRepository>();
            mockRepository.Setup(x => x.GetLast()).Returns(item);

            CafeController controller = controller = new CafeController(mockRepository.Object);
            controller = new CafeController(mockRepository.Object);

            var result = controller.GetLastCoffee() as OkNegotiatedContentResult<CoffeeModel>;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<CoffeeModel>));
        }

        [TestMethod]
        public void Check_GetTypeCoffee()
        {
            var item = GetAllType();

            Mock<ICoffeeRepository> mockRepository = new Mock<ICoffeeRepository>();
            mockRepository.Setup(x => x.GetAllType()).Returns(item);

            CafeController controller = controller = new CafeController(mockRepository.Object);
            controller = new CafeController(mockRepository.Object);

            var result = controller.GetTypeCoffee();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IList<TypeCoffeeModel>));
            Assert.AreEqual(2, result.Count);
        }

        private CoffeeModel GetDemoCoffee()
        {
            return new CoffeeModel()
                            {
                                IdType = 1,
                                Sucre = 2,
                                UseMug = true
                            };
        }

        private IList<TypeCoffeeModel> GetAllType()
        {
            return new List<TypeCoffeeModel>() {
                new TypeCoffeeModel() { Id = 1, TypeDescription = "Cafe"},
                new TypeCoffeeModel() {Id = 2, TypeDescription = "The"}
            };
        }

    }
}
