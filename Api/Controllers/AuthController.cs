using Api.Contract;
using Api.Contract.Base;
using Application.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterRequest req)
        {
            RegisterData registerRes = new();
            var res = new RegisterResponse();
            ///------------------------///
            /// 1 Validate request
            if (!req.IsValid(out string errMsg))
            {
                /// 1.1 That bai -> Tra loi
                res.SetError(ErrorCodes.InvalidReq, errMsg);
            }
            /// 1.2 Thanh cong -> Tiep tuc
            /// 2 Goi xuong Service de tao User
            try
            {
                _authService.RegisterAccount(req.Username!, req.Email, req.Password!);
            }
            catch (Exception ex)
            {
                res.SetError(ErrorCodes.UserExist, ex.Message);
            }
            /// 2.1 That bai -> Tra loi
            /// 2.2 Thanh cong -> Tra ket qua thanh cong
            ///------------------------///
            return Ok(res);
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginRequest req)
        {
            LoginData registerRes = new();
            var res = new LoginResponse();
            ///------------------------///
            /// 1 Validate request
            if (!req.IsValid(out string errMsg))
            {
                /// 1.1 That bai -> Tra loi
                res.SetError(ErrorCodes.InvalidReq, errMsg);
            }
            /// 1.2 Thanh cong -> Tiep tuc
            /// 2 Goi xuong Service de tao User
            _authService.Login(req.Username!, req.Password!);
            /// 2.1 That bai -> Tra loi
            /// 2.2 Thanh cong -> Tra ket qua thanh cong
            ///------------------------///
            return Ok(new LoginResponse(registerRes));
        }
    }
}
