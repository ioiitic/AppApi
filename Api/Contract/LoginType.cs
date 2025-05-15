using Api.Contract.Base;

namespace Api.Contract
{
    public class LoginRequest
    {
        public required string Username { get; set; }
        public required string Password { get; set; }

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

    public class LoginResponse : BaseResponse
    {
        public LoginData? Data { get; set; }

        public LoginResponse() : base()
        {
            Data = null;
        }

        public LoginResponse(LoginData data) : base()
        {
            Data = data;
        }

        public void SetError(ErrorCodes errorCode, string errorMessage)
        {
            Success = false;
            ErrorCode = ErrorCodes.Failure;
            ErrorMessage = errorMessage;
        }
    }

    public class LoginData
    {
        public string Token { get; set; }
        public LoginData()
        {
            Token = string.Empty;
        }
    }
}
