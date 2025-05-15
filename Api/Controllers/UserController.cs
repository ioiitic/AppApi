using Api.Contract.Base;
using Api.Contract;
using Application.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private IAuthService _authService;
        public UserController(IAuthService authService)
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
            /// 2 Goi xuong Repo de tao User
            /// 2.1 That bai -> Tra loi
            /// 2.2 Thanh cong -> Tra ket qua thanh cong
            ///------------------------///
            return Ok(res);
        }
    }
}
