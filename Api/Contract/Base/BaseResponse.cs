namespace Api.Contract.Base
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public ErrorCodes ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public object? Data { get; set; }

        public BaseResponse(object data)
        {
            Success = true;
            ErrorCode = ErrorCodes.Success;
            ErrorMessage = "Success";
            Data = data;
        }
    }
}
