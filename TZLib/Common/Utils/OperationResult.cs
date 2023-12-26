namespace TZLib.Common.Utils
{
    public class OperationResult<T>
    {
        public bool IsSuccess { get; set; }
        public OperationStatus Status { get; set; }
        public T? Data { get; set; }
        public OperationResult(
            bool isSuccess,
            OperationStatus status,
            T? data)
        {
            IsSuccess = isSuccess;
            Status = status;
            Data = data;
        }
    }
}
