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

            extra extra1 = new extra() { id = 1, name = "turbo", category_name = "Engine", price = 20 };
            extra extra2 = new extra() { id = 2, name = "air conditioning", category_name = "Interior", price = 20 };
            extra extra3 = new extra() { id = 3, name = "dark windows", category_name = "Exterior", price = 20 };

            this.mockedRepository
                .Setup(m => m.GetExtraRepo())
                .Returns(new[] { extra1, extra2, extra3 });

            model_extra_connection connection1 = new model_extra_connection() { id = 1, extra_id = 1, model_id = 1 };
            model_extra_connection connection2 = new model_extra_connection() { id = 2, extra_id = 1, model_id = 3 };
            model_extra_connection connection3 = new model_extra_connection() { id = 3, extra_id = 2, model_id = 4 };

            this.mockedRepository
                .Setup(m => m.GetExtraConnectionRepo())
                .Returns(new[] { connection1, connection2, connection3 });

        }

        [Test]
        public void WhenGettingBrandsFromDb_GetsBrands()
        {
            // Mock
            Logic logic = new Logic();
            logic.SetRepositoryInterface(this.mockedRepository.Object);

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
            Logic logic = new Logic();
            logic.SetRepositoryInterface(this.mockedRepository.Object);

            // Act
            var result = logic.GetModelsLogic();

            // Assert
            Assert.That(result.Count(), Is.EqualTo(3));
            Assert.That(result.SingleOrDefault(x => x.name == "406"), Is.Not.Null);
        }

        [Test]
        public void WhenGettingExtrasFromDb_GetsExtras()
        {
            // Mock
            Logic logic = new Logic();
            logic.SetRepositoryInterface(this.mockedRepository.Object);

            // Act
            var result = logic.GetExtraLogic();

            // Assert
            Assert.That(result.Count(), Is.EqualTo(3));
            Assert.That(result.SingleOrDefault(x => x.name == "turbo"), Is.Not.Null);
        }

        [Test]
        public void WhenGettingExtraConnections_GetsExtraConnections()
        {
            Logic logic = new Logic();
            logic.SetRepositoryInterface(this.mockedRepository.Object);

            var result = logic.GetConnectionLogic();

            Assert.That(result.Count(), Is.EqualTo(3));
            Assert.That(result.SingleOrDefault(x => x.id == 3), Is.Not.Null);

        }

        [TestCase("", "Germany", "test.hu", "2018-01-01", "2000")]
        [TestCase("Audi", "", "test.hu", "2018-01-01", "2000")]
        [TestCase("Audi", "Germany", "test.hu", "2018-01-01", "-1000")]
        public void WhenCreatingBrand_WithBadParameters_ExceptionThrown(string name, string country, string url, string date, string revenue)
        {
            Logic logic = new Logic();
            logic.SetRepositoryInterface(this.mockedRepository.Object);
            Assert.Throws(typeof(ArgumentException), () => logic.CreateBrandLogic(name, country, url, date, revenue));
        }

        [TestCase("1", "", "2018-01-01", "300", "400", "10000")]
        [TestCase("1", "Valami", "2018-01-01", "300", "-400", "10000")]
        [TestCase("1", "Ferrari", "2018-01-01", "300", "400", "-10000")]
        [TestCase("4", "Ferrari", "2018-01-01", "300", "400", "10000")]
        public void WhenCreatingModel_WithBadParameters_ExceptionThrown(string id, string name, string start_date, string engine_size, string horsepower, string price)
        {
            Logic logic = new Logic();
            logic.SetRepositoryInterface(this.mockedRepository.Object);
            Assert.Throws(typeof(ArgumentException), () => logic.CreateModelLogic(id, name, start_date, engine_size, horsepower, price));
        }

        [TestCase("", "extra", "black", "1400", "1")]
        [TestCase("test", "extra", "black", "-1400", "1")]
        [TestCase("test", "extra", "black", "1400", "3")]
        public void WhenCreatingExtra_WithBadParameters_ExceptionIsThrown(string categoryName, string extraName, string color, string price, string reusable)
        {
            Logic logic = new Logic();
            logic.SetRepositoryInterface(this.mockedRepository.Object);
            Assert.Throws(typeof(ArgumentException), () => logic.CreateExtraLogic(categoryName, extraName, color, price, reusable));
        }

        [TestCase("id")]
        [TestCase("6")]
        [TestCase("4")]
        public void WhenDeletingBrandWithInvalidId_ExceptionIsThrown(string selection)
        {
            // Arrange
            Logic logic = new Logic();
            logic.SetRepositoryInterface(this.mockedRepository.Object);

            // Act, Assert
            Assert.Throws(typeof(ArgumentException), () => logic.DeleteBrand(selection));

            this.mockedRepository.Verify(
                m => m.DeleteBrandRepo(It.IsAny<car_brands>()), Times.Never);
        }

        [TestCase("1")]
        [TestCase("2")]
        [TestCase("3")]
        public void WhenDeletingBrand_RepositoryIsCalled(string selection)
        {
            // Arrange
            Logic logic = new Logic();

            logic.SetRepositoryInterface(this.mockedRepository.Object);

            // Act
            logic.DeleteBrand(selection);

            // Assert (Verify)
            this.mockedRepository.Verify(m => m.DeleteBrandRepo(It.IsAny<car_brands>()), Times.AtLeastOnce);

        }

        [TestCase("id")]
        [TestCase("7")]
        [TestCase("-1")]
        public void WhenDeletingModelWithInvalidID_ExceptionIsThrown(string selection)
        {
            Logic logic = new Logic();
            logic.SetRepositoryInterface(this.mockedRepository.Object);

            Assert.Throws(typeof(ArgumentException), () => logic.DeleteModel(selection));
        }

        [TestCase("1")]
        [TestCase("2")]
        [TestCase("3")]
        public void WhenDeletingModel_RepositoryIsCalled(string selection)
        {
            Logic logic = new Logic();

            // this.mockedRepository.Setup(m => m.DeleteModelRepo(It.IsAny<car_models>()));
            logic.SetRepositoryInterface(this.mockedRepository.Object);
            logic.DeleteModel(selection);
            this.mockedRepository.Verify(m => m.DeleteModelRepo(It.IsAny<car_models>()),Times.Once);
        }

        [TestCase("id")]
        [TestCase("4")]
        [TestCase("5")]
        public void WhenDeletingExtraWithInvalidID_ExceptionIsThrown(string selection)
        {
            Logic logic = new Logic();
            logic.SetRepositoryInterface(this.mockedRepository.Object);

            Assert.Throws(typeof(ArgumentException), () => logic.DeleteExtra(selection));
        }

        public void WhenDeletingExtra_RepositoryIsCalled(string selection)
        {
            Logic logic = new Logic();

            // this.mockedRepository.Setup(m => m.DeleteModelRepo(It.IsAny<car_models>()));
            logic.SetRepositoryInterface(this.mockedRepository.Object);
            logic.DeleteModel(selection);
            this.mockedRepository.Verify(m => m.DeleteExtraRepo(It.IsAny<extra>()), Times.Once);
        }

        [TestCase("1", "", "", "2019-01-01", "")]
        [TestCase("2", "", "", "Invalid Date", "")]
        [TestCase("3", "", "", "2010-13-04", "")]
        public void WhenUpdatingBrandWithInvalidValues_ExceptionThrwon (string id, string name, string country, string founded, string revenue)
        {
            Logic logic = new Logic();
            logic.SetRepositoryInterface(this.mockedRepository.Object);
            Assert.Throws(typeof(InvalidDateFormatException), () => logic.UpdateBrandLogic(id, name, country, founded, revenue));
        }
    }
}