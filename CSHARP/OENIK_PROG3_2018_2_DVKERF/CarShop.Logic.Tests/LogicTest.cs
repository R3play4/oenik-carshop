// <copyright file="LogicTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

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

    /// <summary>
    /// Test Class
    /// </summary>
    [TestFixture]
    public class LogicTest
    {
        private Mock<ICarRepository> mockedRepository;

        /// <summary>
        /// Sets up mocked repository.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.mockedRepository = new Mock<ICarRepository>();

            car_brands brand1 = new car_brands() { id = 1, name = "Ferari", url = "valami", country = "hungary" };
            car_brands brand2 = new car_brands() { id = 2, name = "Lambo", url = "semmi", country = "italy" };
            car_brands brand3 = new car_brands() { id = 3, name = "Peugeot", url = "halad", country = "france" };

            this.mockedRepository
                .Setup(m => m.ListBrandsRepo())
                .Returns(new[] { brand1, brand2, brand3 });

            car_models model1 = new car_models() { id = 1, brand_id = 2, name = "MurceLago", horsepower = 300 };
            car_models model2 = new car_models() { id = 2, brand_id = 1, name = "Testarosa", horsepower = 120 };
            car_models model3 = new car_models() { id = 3, brand_id = 3, name = "406", horsepower = 60 };

            this.mockedRepository
                .Setup(m => m.ListModelsRepo())
                .Returns(new[] { model1, model2, model3 });

            extra extra1 = new extra() { id = 1, name = "turbo", category_name = "Engine", price = 20 };
            extra extra2 = new extra() { id = 2, name = "air conditioning", category_name = "Interior", price = 20 };
            extra extra3 = new extra() { id = 3, name = "dark windows", category_name = "Exterior", price = 20 };

            this.mockedRepository
                .Setup(m => m.ListExtraRepo())
                .Returns(new[] { extra1, extra2, extra3 });

            model_extra_connection connection1 = new model_extra_connection() { id = 1, extra_id = 1, model_id = 1 };
            model_extra_connection connection2 = new model_extra_connection() { id = 2, extra_id = 1, model_id = 3 };
            model_extra_connection connection3 = new model_extra_connection() { id = 3, extra_id = 2, model_id = 4 };

            this.mockedRepository
                .Setup(m => m.ListExtraConnectionRepo())
                .Returns(new[] { connection1, connection2, connection3 });
        }

        /// <summary>
        /// Checks if proper Brand is returned by the logic.
        /// </summary>
        [Test]
        public void WhenGettingBrandsFromDb_GetsBrands()
        {
            // Mock
            CarLogic logic = new CarLogic();
            logic.SetRepositoryInterface(this.mockedRepository.Object);

            // Act
            var result = logic.ListBrandLogic();

            // Assert
            Assert.That(result.Count(), Is.EqualTo(3));
            Assert.That(result.SingleOrDefault(x => x.name == "Ferari"), Is.Not.Null);
        }

        /// <summary>
        /// Checks if proper Model is returned by the logic.
        /// </summary>
        [Test]
        public void WhenGettingModelsFromDb_GetsModels()
        {
            // Mock
            CarLogic logic = new CarLogic();
            logic.SetRepositoryInterface(this.mockedRepository.Object);

            // Act
            var result = logic.ListModelLogic();

            // Assert
            Assert.That(result.Count(), Is.EqualTo(3));
            Assert.That(result.SingleOrDefault(x => x.name == "406"), Is.Not.Null);
        }

        /// <summary>
        /// Checks if proper Extra is returned by the logic.
        /// </summary>
        [Test]
        public void WhenGettingExtrasFromDb_GetsExtras()
        {
            // Mock
            CarLogic logic = new CarLogic();
            logic.SetRepositoryInterface(this.mockedRepository.Object);

            // Act
            var result = logic.ListExtraLogic();

            // Assert
            Assert.That(result.Count(), Is.EqualTo(3));
            Assert.That(result.SingleOrDefault(x => x.name == "turbo"), Is.Not.Null);
        }

        /// <summary>
        /// Checks if proper extra connection is returned.
        /// </summary>
        [Test]
        public void WhenGettingExtraConnections_GetsExtraConnections()
        {
            CarLogic logic = new CarLogic();
            logic.SetRepositoryInterface(this.mockedRepository.Object);

            var result = logic.ListConnectionLogic();

            Assert.That(result.Count(), Is.EqualTo(3));
            Assert.That(result.SingleOrDefault(x => x.id == 3), Is.Not.Null);
        }

        /// <summary>
        /// Tests if the values for the new Brands are properly set by the user.
        /// </summary>
        /// <param name="name">new name</param>
        /// <param name="country">new country</param>
        /// <param name="url">new url</param>
        /// <param name="date">new date</param>
        /// <param name="revenue">new revenue</param>
        [TestCase("", "Germany", "test.hu", "2018-01-01", "2000")]
        [TestCase("Audi", "", "test.hu", "2018-01-01", "2000")]
        [TestCase("Audi", "Germany", "test.hu", "2018-01-01", "-1000")]
        public void WhenCreatingBrand_WithBadParameters_ExceptionThrown(string name, string country, string url, string date, string revenue)
        {
            CarLogic logic = new CarLogic();
            logic.SetRepositoryInterface(this.mockedRepository.Object);
            Assert.Throws(typeof(InvalidParameterException), () => logic.CreateBrandLogic(name, country, url, date, revenue));
        }

        /// <summary>
        /// Tests if the values for the new Model are properly set by the user.
        /// </summary>
        /// <param name="id">new id</param>
        /// <param name="name">new name</param>
        /// <param name="startDate">new date</param>
        /// <param name="engineSize">new size</param>
        /// <param name="horsePower">new horsepower</param>
        /// <param name="price">new price</param>
        [TestCase("1", "", "2018-01-01", "300", "400", "10000")]
        [TestCase("1", "Valami", "2018-01-01", "300", "-400", "10000")]
        [TestCase("1", "Ferrari", "2018-01-01", "300", "400", "-10000")]
        [TestCase("4", "Ferrari", "2018-01-01", "300", "400", "10000")]
        public void WhenCreatingModel_WithBadParameters_ExceptionThrown(string id, string name, string startDate, string engineSize, string horsePower, string price)
        {
            CarLogic logic = new CarLogic();
            logic.SetRepositoryInterface(this.mockedRepository.Object);
            Assert.Throws(typeof(InvalidParameterException), () => logic.CreateModelLogic(id, name, startDate, engineSize, horsePower, price));
        }

        /// <summary>
        /// Tests if the values for the new Extra are properly set by the user.
        /// </summary>
        /// <param name="categoryName">new category name</param>
        /// <param name="extraName">new extra name</param>
        /// <param name="color">new color</param>
        /// <param name="price">new price</param>
        /// <param name="reusable">new reusebla value</param>
        [TestCase("", "extra", "black", "1400", "1")]
        [TestCase("test", "extra", "black", "-1400", "1")]
        [TestCase("test", "extra", "black", "1400", "3")]
        public void WhenCreatingExtra_WithBadParameters_ExceptionIsThrown(string categoryName, string extraName, string color, string price, string reusable)
        {
            CarLogic logic = new CarLogic();
            logic.SetRepositoryInterface(this.mockedRepository.Object);
            Assert.Throws(typeof(InvalidParameterException), () => logic.CreateExtraLogic(categoryName, extraName, color, price, reusable));
        }

        /// <summary>
        /// Checks logic thorws exception when user tries to delete with bad parameters
        /// </summary>
        /// <param name="selection">id of the brand that needs to be deleted</param>
        [TestCase("id")]
        [TestCase("6")]
        [TestCase("4")]
        public void WhenDeletingBrandWithInvalidId_ExceptionIsThrown(string selection)
        {
            // Arrange
            CarLogic logic = new CarLogic();
            logic.SetRepositoryInterface(this.mockedRepository.Object);

            // Act, Assert
            Assert.Throws(typeof(InvalidParameterException), () => logic.DeleteBrand(selection));

            this.mockedRepository.Verify(
                m => m.DeleteBrandRepo(It.IsAny<car_brands>()), Times.Never);
        }

        /// <summary>
        /// Checks if repository was called once
        /// </summary>
        /// <param name="selection">id of the brand</param>
        [TestCase("1")]
        [TestCase("2")]
        [TestCase("3")]
        public void WhenDeletingBrand_RepositoryIsCalled(string selection)
        {
            // Arrange
            CarLogic logic = new CarLogic();

            logic.SetRepositoryInterface(this.mockedRepository.Object);

            // Act
            logic.DeleteBrand(selection);

            // Assert (Verify)
            this.mockedRepository.Verify(m => m.DeleteBrandRepo(It.IsAny<car_brands>()), Times.AtLeastOnce);
        }

        /// <summary>
        /// Checks logic thorws exception when user tries to delete with bad parameters
        /// </summary>
        /// <param name="selection">id of the model that needs to be deleted.</param>
        [TestCase("id")]
        [TestCase("7")]
        [TestCase("-1")]
        public void WhenDeletingModelWithInvalidId_ExceptionIsThrown(string selection)
        {
            CarLogic logic = new CarLogic();
            logic.SetRepositoryInterface(this.mockedRepository.Object);

            Assert.Throws(typeof(InvalidParameterException), () => logic.DeleteModel(selection));
        }

        /// <summary>
        /// Checks if repository was called once
        /// </summary>
        /// <param name="selection">id of the model</param>
        [TestCase("1")]
        [TestCase("2")]
        [TestCase("3")]
        public void WhenDeletingModel_RepositoryIsCalled(string selection)
        {
            CarLogic logic = new CarLogic();

            // this.mockedRepository.Setup(m => m.DeleteModelRepo(It.IsAny<car_models>()));
            logic.SetRepositoryInterface(this.mockedRepository.Object);
            logic.DeleteModel(selection);
            this.mockedRepository.Verify(m => m.DeleteModelRepo(It.IsAny<car_models>()), Times.Once);
        }

        /// <summary>
        /// Checks logic thorws exception when user tries to delete with bad parameters
        /// </summary>
        /// <param name="selection">id of the extra that needs to be deleted</param>
        [TestCase("id")]
        [TestCase("4")]
        [TestCase("5")]
        public void WhenDeletingExtraWithInvalidId_ExceptionIsThrown(string selection)
        {
            CarLogic logic = new CarLogic();
            logic.SetRepositoryInterface(this.mockedRepository.Object);

            Assert.Throws(typeof(InvalidParameterException), () => logic.DeleteExtra(selection));
        }

        /// <summary>
        /// Checks if repository was called once
        /// </summary>
        /// <param name="selection">id of the extra</param>
        public void WhenDeletingExtra_RepositoryIsCalled(string selection)
        {
            CarLogic logic = new CarLogic();

            // this.mockedRepository.Setup(m => m.DeleteModelRepo(It.IsAny<car_models>()));
            logic.SetRepositoryInterface(this.mockedRepository.Object);
            logic.DeleteModel(selection);
            this.mockedRepository.Verify(m => m.DeleteExtraRepo(It.IsAny<extra>()), Times.Once);
        }

        /// <summary>
        /// Checks logic thorws exception when user tries to update with bad parameters
        /// </summary>
        /// <param name="id">brand id</param>
        /// <param name="name">brand name</param>
        /// <param name="country">brand country</param>
        /// <param name="founded">foundation date</param>
        /// <param name="revenue">revenue</param>
        [TestCase("1", "", "", "2019-01-01", "")]
        [TestCase("2", "", "", "Invalid Date", "")]
        [TestCase("3", "", "", "2010-13-04", "")]
        public void WhenUpdatingBrandWithInvalidValues_ExceptionThrwon(string id, string name, string country, string founded, string revenue)
        {
            CarLogic logic = new CarLogic();
            logic.SetRepositoryInterface(this.mockedRepository.Object);
            Assert.Throws(typeof(InvalidParameterException), () => logic.UpdateBrandLogic(id, name, country, founded, revenue));
        }
    }
}