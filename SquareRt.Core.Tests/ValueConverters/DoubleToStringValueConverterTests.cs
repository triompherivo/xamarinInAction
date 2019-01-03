using System;
using NUnit.Framework;
using SquareRt.Core.ValueConverters;

namespace SquareRt.Core.Tests.ValueConverters
{
    [TestFixture]
    public class DoubleToStringValueConverterTests
    {
        [Test]
        public void Convert_ConvertAsDoubleToString()
        {
            //Arrange
            var vc = new DoubleToStringValueConverter();
            //Act
            var converted = vc.Convert(123.456, null, null, null);
            //Assert
            Assert.AreEqual("123,456", converted);
        }
        [Test]
        public void ConvertBack_ConvertsAsStringToDouble()
        {
            //Arrange
            var vc= new DoubleToStringValueConverter();
            //Act
            var converted = vc.ConvertBack("123,456", null, null, null);
            //Assert
            Assert.AreEqual(123.456, converted);
        }
    }
}
