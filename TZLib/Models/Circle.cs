using TZLib.Common.Utils;
using TZLib.Interfaces;

namespace TZLib.Models
{
    public class Circle : IShape
    {
        private double Radius { get; }
        private double? cachedArea;
        public double GetRadius()
        {
            return Radius;
        }
        public Circle(double radius)
        {
            Radius = radius;
        }
        public OperationResult<double?> GetArea()
        {
            
            //в принципе радиус может быть 0 в математике и круг может быть с нулевой площадью, но всё-таки я буду обрабатывать это как InvalidSides
            if (Radius <= 0)
                return new OperationResult<double?>(
                    false, OperationStatus.InvalidSides, null);

            if (cachedArea.HasValue)
            {
                return new OperationResult<double?>(true, OperationStatus.Success, cachedArea.Value);
            }

            var area = Math.PI * Math.Pow(Radius, 2);
            cachedArea = area;


            return new OperationResult<double?>(true, OperationStatus.Success, area);
        }
    }
}
