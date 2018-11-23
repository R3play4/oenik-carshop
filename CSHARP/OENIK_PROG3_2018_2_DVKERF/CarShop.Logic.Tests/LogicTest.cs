namespace CarShop.Logic.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CarShop.Data;
    using CarShop.Repository;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class LogicTest
    {
        private Mock<IRepository> mockedRepository;

        [SetUp]
        public void Setup()
        {
            this.mockedRepository = new Mock<IRepository>();

            car_brands brand1 = new car_brands() { id = 1, name = "Ferari", url = "valami", country = "hungary" };
            car_brands brand2 = new car_brands() { id = 2, name = "Lambo", url = "semmi", country = "italy" };
            car_brands brand3 = new car_brands() { id = 3, name = "Peugeot", url = "halad", country = "france" };

            this.mockedRepository
                .Setup(m => m.GetBrandsRepo())
                .Returns(new[] { brand1, brand2, brand3 });

            car_models model1 = new car_models() { id = 1, brand_id = 2, name = "MurceLago", horsepower = 300 };
            car_models model2 = new car_models() { id = 2, brand_id = 1, name = "Testarosa", horsepower = 120 };
            car_models model3 = new car_models() { id = 3, brand_id = 3, name = "406", horsepower = 60 };

            this.mockedRepository
                .Setup(m => m.GetModelsRepo())
                .Returns(new[] { model1, model2, model3 });
        }

        [Test]
        public void WhenGettingBrandsFromDb_GetsBrands()
        {
            // Mock
            Logic logic = new Logic(this.mockedRepository.Object);

            // Act
            var result = logic.GetBrandsLogic();

            // Assert
            Assert.That(result.Count(), Is.EqualTo(3));
            Assert.That(result.SingleOrDefault(x => x.name == "Ferari"), Is.Not.Null);

        }

        [Test]
        public void WhenGettingModelsFromDb_GetsModels()
        {
            // Mock
            Logic logic = new Logic(this.mockedRepository.Object);

            // Act
            var result = logic.GetModelsLogic();

            // Assert
            Assert.That(result.Count(), Is.EqualTo(3));
            Assert.That(result.SingleOrDefault(x => x.name == "406"), Is.Not.Null);

        }
    }
}