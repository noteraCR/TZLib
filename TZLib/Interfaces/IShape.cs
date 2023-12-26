using TZLib.Common.Utils;

namespace TZLib.Interfaces
{
    public interface IShape
    {
        OperationResult<double?> GetArea();
    }
}
