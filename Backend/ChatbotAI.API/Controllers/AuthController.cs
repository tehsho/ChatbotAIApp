using ChatbotAI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChatbotAI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // DTO for login/register requests
        public class AuthRequest
        {
            public string Username { get; set; } = null!;
            public string Password { get; set; } = null!;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthRequest credentials)
        {
            var user = await _authService.AuthenticateAsync(credentials.Username, credentials.Password);
            if (user is null)
                return Unauthorized();

            return Ok((object)user);
        }       
    }
}
