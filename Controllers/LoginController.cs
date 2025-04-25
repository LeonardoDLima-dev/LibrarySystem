using LibrarySystem.Models;
using LibrarySystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] User user)
        {
            var token = _userService.Authenticate(user.Username, user.Password);

            if (token == null)
                return Unauthorized();

            return Ok(new { Token = token });
        }
    }
}
