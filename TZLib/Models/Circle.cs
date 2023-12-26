using TZLib.Common.Utils;
using TZLib.Interfaces;

namespace TZLib.Models
{
    public class Circle : IShape
    {
        public double Radius { get; set; }

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

            var area = Math.PI * Math.Pow(Radius, 2);

            return new OperationResult<double?>(true, OperationStatus.Success, area);
        }
    }
}
