using TZLib.Common.Utils;
using TZLib.Interfaces;
using TZLib.Models;

namespace TZLib.Services
{
    public static class GeometryLibrary
    {
        private static readonly Type[] validTypes = { typeof(Circle), typeof(Triangle) };
        
        public static OperationResult<double?> CalculateShapeArea(IShape shape)
        {
            var validationStatus = ValidateShape(shape);
            if (validationStatus != OperationStatus.Success)
                return CreateResultWithDefaultData<double?>(validationStatus);

            return shape.GetArea();
        }
        public static OperationResult<double?> CalculateShapeArea(params double[] sides)
        {
            var shape = CreateShape(sides);
            var validationStatus = ValidateShape(shape);
            return validationStatus != OperationStatus.Success ? CreateResultWithDefaultData<double?>(validationStatus) : shape!.GetArea();
        }
        
        public static OperationResult<bool?> IsTriangleRectangular(Triangle? triangle)
        {
            var validationStatus = ValidateShape(triangle);

            return validationStatus != OperationStatus.Success
                ? CreateResultWithDefaultData<bool?>(validationStatus)
                : triangle!.IsTriangleRectangular();
        }

        public static OperationResult<bool?> IsTriangleRectangular(params double[] sides)
        {
            if (sides.Length != 3)
                return CreateResultWithDefaultData<bool?>(OperationStatus.InvalidInput);
            var triangle = CreateShape(sides) as Triangle;


            return IsTriangleRectangular(triangle);
        }
        private static OperationStatus ValidateShape(IShape? shape)
        {
            if (shape == null)
                return OperationStatus.InvalidInput;

            if (!IsValidType(shape))
                return OperationStatus.ShareNotSupported;

            return OperationStatus.Success;
        }
        private static bool IsValidType(IShape shape) => 
            validTypes.Contains(shape.GetType());
        
        private static IShape? CreateShape(params double[] sidesOrRadius)
        {
            return sidesOrRadius.Length switch
            {
                1 => new Circle(sidesOrRadius[0]),
                3 => new Triangle(sidesOrRadius[0], sidesOrRadius[1], sidesOrRadius[2]),
                _ => null
            };
        }
        private static OperationResult<T> CreateResultWithDefaultData<T>(OperationStatus status)
        {
            return new OperationResult<T>(false, status, default);
        }
    }
    
}
