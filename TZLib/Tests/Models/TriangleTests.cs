using TZLib.Common.Utils;
using TZLib.Models;
using Xunit;

namespace TZLib.Tests.Models
{
    public class TriangleTests
    {
        [Fact]
        public void GetArea_ValidTriangle_ReturnsCorrectArea()
        {
            double a = 3, b = 4, c = 5;
            var triangle = new Triangle(a, b, c);
            var expectedArea = 6.0;

            var result = triangle.GetArea();

            Assert.True(result.IsSuccess);
            Assert.Equal(OperationStatus.Success, result.Status);
            Assert.Equal(expectedArea, result.Data);
        }

        [Fact]
        public void GetArea_InvalidTriangle_ReturnsInvalidSidesStatus()
        {
            double a = 1, b = 1, c = 10;
            var triangle = new Triangle(a, b, c);

            var result = triangle.GetArea();

            Assert.False(result.IsSuccess);
            Assert.Equal(OperationStatus.InvalidSides, result.Status);
            Assert.Null(result.Data);
        }

        [Fact]
        public void IsTriangleRectangular_ValidRightAngledTriangle_ReturnsTrue()
        {
            double a = 3, b = 4, c = 5;
            var triangle = new Triangle(a, b, c);

            var result = triangle.IsTriangleRectangular();

            Assert.True(result.IsSuccess);
            Assert.Equal(OperationStatus.Success, result.Status);
            Assert.True(result.Data);
        }

        [Fact]
        public void IsTriangleRectangular_ValidSimpleTriangle_ReturnsFalse()
        {
            double a = 3, b = 4, c = 6;
            var triangle = new Triangle(a, b, c);

            var result = triangle.IsTriangleRectangular();

            Assert.True(result.IsSuccess);
            Assert.Equal(OperationStatus.Success, result.Status);
            Assert.False(result.Data);
        }

        [Fact]
        public void IsTriangleRectangular_InvalidTriangle_ReturnsInvalidSidesStatus()
        {
            double a = 1, b = 1, c = 10;
            var triangle = new Triangle(a, b, c);

            var result = triangle.IsTriangleRectangular();

            Assert.False(result.IsSuccess);
            Assert.Equal(OperationStatus.InvalidSides, result.Status);
            Assert.Null(result.Data);
        }
    }
}
