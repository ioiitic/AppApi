namespace Api.Contract.Base
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public ErrorCodes ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        public BaseResponse()
        {
            Success = true;
            ErrorCode = ErrorCodes.Success;
            ErrorMessage = "Success";
        }
    }
}
