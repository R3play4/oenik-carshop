using CarShop.Repository; // Ezt lehet majd ki kell szedni és egy másik interfacet használni ehez.
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Logic.Tests
{
    [TestFixture]
    public class LogicTest
    {
        private Mock<IRepository> mockedRepository;

        [SetUp]
        public void Setup()
        {
            this.mockedRepository = new Mock<IRepository>();

            mockedRepository
                .Setup(m => m.MokkFugveny())
                .Verifiable();

        }
    }
}
