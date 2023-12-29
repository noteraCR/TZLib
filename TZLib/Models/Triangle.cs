using TZLib.Common.Utils;
using TZLib.Interfaces;

namespace TZLib.Models
{
    public class Triangle : IShape
    {
        private double A { get; }
        private double B { get; }
        private double C { get; }

        private double? cachedArea;
        private bool? cachedIsTriangleRectangular;

        public Triangle(double a, double b, double c)
        {
            A = a; B = b; C = c;
        }
        public OperationResult<double?> GetArea()
        {
            if (!IsTrianglePossible())
                return new OperationResult<double?>(false, OperationStatus.InvalidSides, null);

            if (cachedArea.HasValue)
            {
                return new OperationResult<double?>(true, OperationStatus.Success, cachedArea.Value);
            }

            var p = (A + B + C) / 2; //p - полу-периметр;
            var area = Math.Sqrt(p * (p - A) * (p - B) * (p - C));
            cachedArea = area;


            return new OperationResult<double?>(true, OperationStatus.Success, area);
        }

        public OperationResult<bool?> IsTriangleRectangular()
        {
            if (!IsTrianglePossible())
                return new OperationResult<bool?>(false, OperationStatus.InvalidSides, null);

            if (cachedIsTriangleRectangular.HasValue)
            {
                return new OperationResult<bool?>(true, OperationStatus.Success, cachedIsTriangleRectangular.Value);
            }

            var isTriangleRectangular = CalculateIsTreangleRectangular();
            cachedIsTriangleRectangular = isTriangleRectangular;

            return new OperationResult<bool?>(true, OperationStatus.Success, isTriangleRectangular);
        }
        private bool CalculateIsTreangleRectangular()
        {
            double[] sides = new double[] { A, B, C };
            Array.Sort(sides);

            double aSquared = sides[0] * sides[0];
            double bSquared = sides[1] * sides[1];
            double cSquared = sides[2] * sides[2];

            return (aSquared + bSquared == cSquared);
        }
        private bool IsTrianglePossible()
        {
            return ((A + B > C) && (B + C > A) && (A + C > B)) && (A >= 0 || B >= 0 || C >= 0);
        }


    }
}
