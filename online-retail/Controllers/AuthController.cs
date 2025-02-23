using Microsoft.AspNetCore.Mvc;
using online_retail.Models.ViewModels;
using online_retail.Services.Interface;

namespace online_retail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        public AuthController(IUserService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            var user = await _userService.ValidateUser(model.Email, model.Password);

            if (user == null)
                return Unauthorized(new { message = "Invalid credentials" });

            string token = _jwtService.GenerateJwtToken(user);
            return Ok(new { Token = token });
        }
    }
}
