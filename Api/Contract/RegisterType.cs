using Api.Contract.Base;

namespace Api.Contract
{
    public class RegisterRequest
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public bool IsValid(out string errMsg)
        {
            errMsg = string.Empty;
            if (string.IsNullOrEmpty(Username))
            {
                errMsg += $"Field {nameof(Username)} is invalid";
            }
            if (string.IsNullOrEmpty(Password))
            {
                errMsg += $"Field {nameof(Password)} is invalid";
            }
            return string.IsNullOrEmpty(errMsg);
        }
    }

    public class RegisterResponse : BaseResponse
    {
        public RegisterData? Data { get; set; }

        public RegisterResponse() : base() 
        {
            Data = null;
        }

        public RegisterResponse(RegisterData data) : base()
        {
            Data = data;
        }

        public void SetError(ErrorCodes errorCode, string errorMessage)
        {
            Success = false;
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }
    }

    public class RegisterData
    {
        public string Token { get; set; }
        public RegisterData()
        {
            Token = string.Empty;
        }
    }
}
