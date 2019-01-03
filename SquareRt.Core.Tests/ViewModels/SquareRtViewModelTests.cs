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
        [Test]
        public void Number_ConvertsToAndFromDoubleCorrectly()
        {
            //Act
            viewModel.Number = "1234,4321";
            //Assert
            Assert.AreEqual("1234,4321", viewModel.Number);
            	
        }
        [Test]
        public void SettingNumber_RaisePropertyChanged()
        {
            //Arrange
            var propertyChangedRaised = false;
            viewModel.PropertyChanged += (s, e) => propertyChangedRaised = (e.PropertyName == "Number");
            //Act
            viewModel.Number = "1";
            //Assert
            Assert.IsTrue(propertyChangedRaised);
        }


    }
}
