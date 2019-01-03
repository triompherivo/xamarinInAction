using System;
using Moq;
using NUnit.Framework;
using SquareRt.Core.ViewModels;

namespace SquareRt.Core.Tests.ViewModels
{
    [TestFixture]
    public class SquareRtViewModelTests
    {
        Mock<ISquareRtCalculator> calculator;
        SquareRtViewModel viewModel;
        [SetUp]
        public void SetUp()
        {
            calculator = new Mock<ISquareRtCalculator>();
            viewModel = new SquareRtViewModel(calculator.Object);
            viewModel.ShouldAlwaysRaiseInpcOnUserInterfaceThread(false);
        }
        //[Test]
        //public void Number_ConvertsToAndFromDoubleCorrectly()
        //{
        //    //Act
        //    viewModel.Number = 1234.4321;
        //    //Assert
        //    Assert.AreEqual(1234.4321, viewModel.Number);

        //}
        [Test]
        public void SettingNumber_RaisePropertyChanged()
        {
            //Arrange
            var propertyChangedRaised = false;
            viewModel.PropertyChanged += (s, e) => propertyChangedRaised = (e.PropertyName == "Number");
            //Act
            viewModel.Number = 1;
            //Assert
            Assert.IsTrue(propertyChangedRaised);
        }
        [Test]
        public void SettingNumber_CalculateResult()
        {
            //arrange
            calculator.Setup(c => c.Calculate(It.IsAny<double>()))
                .Returns(2);
            //Act
            viewModel.Number = 4;
            //Assert
            Assert.AreEqual(2, viewModel.Result);
        }
        [Test]
        public void SettingNumber_RaisePropertychangedForResult()
        {
            //Arrange
            calculator.Setup(c => c.Calculate(It.IsAny<double>())).Returns(2);
            var propertyChanged = false;
            viewModel.PropertyChanged += (s, e) => propertyChanged = (e.PropertyName == "Result");
            //Act
            viewModel.Number = 1;
            //Assert
            Assert.IsTrue(propertyChanged);

        }


    }
}
