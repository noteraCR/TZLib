using TZLib.Common.Utils;
using TZLib.Models;
using Xunit;


namespace TZLib.Tests.Models
{
    
    public class CircleTests
    {
        [Fact]
        public void GetArea_RadiusGreaterThanZero_ReturnsCorrectArea()
        {
            double radius = 5;
            var circle = new Circle(radius);
            var expectedArea = Math.PI * Math.Pow(radius, 2);

            var result = circle.GetArea();

            Assert.True(result.IsSuccess);
            Assert.Equal(OperationStatus.Success, result.Status);
            Assert.Equal(expectedArea, result.Data);
        }

        [Fact]
        public void GetArea_RadiusEqualsZero_ReturnsInvalidSidesStatus()
        {
            double radius = 0;
            var circle = new Circle(radius);

            var result = circle.GetArea();

            Assert.False(result.IsSuccess);
            Assert.Equal(OperationStatus.InvalidSides, result.Status);
            Assert.Null(result.Data);
        }

        [Fact]
        public void GetArea_RadiusLessThanZero_ReturnsInvalidSidesStatus()
        {
            double radius = -2;
            var circle = new Circle(radius);

            var result = circle.GetArea();

            Assert.False(result.IsSuccess);
            Assert.Equal(OperationStatus.InvalidSides, result.Status);
            Assert.Null(result.Data);
        }
    }
}
