using Api.Contract.Base;
using Api.Contract;
using Application.Services.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize(Roles = "Admin")]
        public IActionResult Test()
        {
            return Ok();
        }
    }
}
