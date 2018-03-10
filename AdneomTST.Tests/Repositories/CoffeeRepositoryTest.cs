using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdneomTST.Models.Repositories;
using AdneomTST.Models.ViewModels;

namespace AdneomTST.Tests.Repositories
{
    [TestClass]
    public class CoffeeRepositoryTest
    {

        [TestMethod]
        public void WheAddCoffee_ThenGetItAsLastCoffee()
        {
            var item = GetDemoCoffee();

            var coffeeRepository = new CoffeeRepository();
            coffeeRepository.Add(item);

            var lastCoffee = coffeeRepository.GetLast();

            Assert.IsNotNull(lastCoffee);
            Assert.AreEqual(item.IdType, lastCoffee.IdType);
            Assert.AreEqual(item.Sucre, lastCoffee.Sucre);
            Assert.AreEqual(item.UseMug, lastCoffee.UseMug);
        }

        [TestMethod]
        public void WhenGettingAllTypes_ThenAllTypesAreReturned()
        {
            var coffeeRepository = new CoffeeRepository();

            var typesCoffee = coffeeRepository.GetAllType();

            Assert.IsNotNull(typesCoffee);
            Assert.AreEqual(3, typesCoffee.Count());
        }

        [TestMethod]
        public void WhenGettingAllTypes_ThenTypesIncludeName()
        {
            var coffeeRepository = new CoffeeRepository();

            var typesCoffee = coffeeRepository.GetAllType();

            Assert.IsNotNull(typesCoffee);
            Assert.AreEqual("The", typesCoffee[0].TypeDescription);
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

    }
}
