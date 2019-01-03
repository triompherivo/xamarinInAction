using System;
using NUnit.Framework;
using System.Threading.Tasks;
namespace SquareRt.Core.Tests
{
    [TestFixture]
    public class SquareRtCalculatorTests
    {
        ISquareRtCalculator calc;
        [SetUp]
        public void SetUp()
        {
            //Arrange
           calc = new SquareRtCalculator();

        }
        [Test]
        public /*async  Task */ void Calculate_4_Returns2()
        {
            //Act
            //var squareRoot = await calc.Calculate(4);

            var squareRoot = calc.Calculate(4);
            //Assert
            Assert.AreEqual(2, squareRoot);
        }
    }
}
