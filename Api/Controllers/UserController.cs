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
        private IAuthService1 _authService1;
        private IAuthService2 _authService2;
        private IAuthService3 _authService3;
        public UserController(IAuthService1 authService1, IAuthService2 authService2, IAuthService3 authService3)
        {
            _authService1 = authService1;
            _authService2 = authService2;
            _authService3 = authService3;
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
