using TZLib.Common.Utils;
using Xunit;

namespace TZLib.Tests.Common.Utils
{
    public class OperationResultTests
    {
        [Fact]
        public void OperationResult_Success_IsSuccessTrue()
        {
            var result = new OperationResult<double>(true, OperationStatus.Success, 1.0);

            Assert.True(result.IsSuccess);
            Assert.Equal(OperationStatus.Success, result.Status);
            Assert.Equal(1.0, result.Data);
        }

        [Fact]
        public void OperationResult_Failure_IsSuccessFalse()
        {
            var result = new OperationResult<string>(false, OperationStatus.UnexpectedError, null);

            Assert.False(result.IsSuccess);
            Assert.Equal(OperationStatus.UnexpectedError, result.Status);
            Assert.Null(result.Data);
        }

    }
}
