using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using SquareRt.Core.Models;
using SquareRt.Core.Repositories;
using SquareRt.Core.Services;

namespace SquareRt.Core.Tests.Services
{
    [TestFixture]
    public class CountersServiceTests
    {
        private ICountersService service;
        private Mock<ICountersRepository> repo;

        [SetUp]
        public void SetUp()
        {
            repo=new Mock<ICountersRepository>();
            service= new CountersService(repo.Object);
        }

        [Test]
        public async Task IncrementCounter_IncrementsTheCounter()
        {
            //Arrange
            var counter = new Counter {Count = 0};
            //Act
            await service.IncrementCounter(counter);
            //Assert
            Assert.AreEqual(1,counter.Count);
        }

        [Test]
        public async Task IncrementCounter_SavesTheIncrementedCounter()
        {
            //Arrange
            var counter = new Counter {Count = 0};
            //Act
            await service.IncrementCounter(counter);
            //Assert
            repo.Verify(r=> r.Save(It.Is<Counter>(c=>c.Count == 1)),Times.Once);
        }

        [Test]
        public async Task GetAllCounters_ReturnsAllCountersFromTheRepository()
        {
            //Arrange
            var counters = new List<Counter>
            {
                new Counter {Name = "Counter1"},
                new Counter {Name = "Counter2"}
            };
            repo.Setup(r=>r.GetAll()).ReturnsAsync(counters);
                
            //Act
            var results = await service.GetAllCounters();
            //Assert
            CollectionAssert.AreEqual(results,counters);
        }
    }
}