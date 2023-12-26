using TZLib.Common.Utils;
using Xunit;

namespace TZLib.Tests.Common.Utils
{
    public class OperationStatusTests
    {
        [Fact]
        public void OperationStatus_EnumValuesAreDefined()
        {
            Assert.Equal(0, (int)OperationStatus.Success);
            Assert.Equal(1, (int)OperationStatus.InvalidInput);
            Assert.Equal(2, (int)OperationStatus.ShareNotSupported);
            Assert.Equal(3, (int)OperationStatus.UnexpectedError);
            Assert.Equal(4, (int)OperationStatus.InvalidSides);
            Assert.Equal(5, (int)OperationStatus.NonPositiveParameters);
        }
    }
}
