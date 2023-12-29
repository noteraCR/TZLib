using TZLib.Common.Utils;
using TZLib.Models;
using TZLib.Services;
using Xunit;

namespace TZLib.Tests.Services
{
    public class GeometryLibraryTests
    {
        [Fact]
        public void CalculateShapeArea_WithCircle_ReturnsCorrectArea()
        {
            var circle = new Circle(5);
            double expected = Math.PI * Math.Pow(circle.GetRadius(), 2);

            var result = GeometryLibrary.CalculateShapeArea(circle);

            Assert.True(result.IsSuccess);
            Assert.Equal(OperationStatus.Success, result.Status);
            Assert.Equal(expected, result.Data!.Value, precision: 6);
        }

        [Fact]
        public void CalculateShapeArea_WithInvalidCircle_ReturnsError()
        {
            var circle = new Circle(-1);

            var result = GeometryLibrary.CalculateShapeArea(circle);

            Assert.False(result.IsSuccess);
            Assert.Equal(OperationStatus.InvalidInput, result.Status);
            Assert.Null(result.Data);
        }

        [Fact]
        public void CalculateShapeArea_WithTriangle_ReturnsCorrectArea()
        {
            var triangle = new Triangle(3, 4, 5);
            double expected = 6;

            var result = GeometryLibrary.CalculateShapeArea(triangle);

            Assert.True(result.IsSuccess);
            Assert.Equal(OperationStatus.Success, result.Status);
            Assert.Equal(expected, result.Data!.Value, precision: 6);
        }

        [Fact]
        public void IsTriangleRectangular_WithRightTriangle_ReturnsTrue()
        {
            var triangle = new Triangle(3, 4, 5);

            var result = GeometryLibrary.IsTriangleRectangular(triangle);

            Assert.False(result.IsSuccess);
                        Assert.Equal(OperationStatus.Success, result.Status);
            Assert.True(result.Data);
        }

        [Fact]
        public void IsTriangleRectangular_WithNull_ReturnsInvalidInputError()
        {
            Triangle? triangle = null;

            var result = GeometryLibrary.IsTriangleRectangular(triangle);

            Assert.False(result.IsSuccess);
            Assert.Equal(OperationStatus.InvalidInput, result.Status);
            Assert.Null(result.Data);
        }
    }
}
