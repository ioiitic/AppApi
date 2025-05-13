using Api.Contract.Base;

namespace Api.Contract
{
    public class LoginRequest
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }

    public class LoginResponse
    {
        public bool Success { get; set; }
        public ErrorCodes ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public LoginData? Data { get; set; }

        public LoginResponse(LoginData data)
        {
            Success = true;
            ErrorCode = ErrorCodes.Success;
            ErrorMessage = "Success";
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
