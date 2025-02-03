using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using JobSearchAppBackend.DTOs;
using JobSearchAppBackend.Interfaces;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    /// <summary>
    /// Registers a new user and returns a JWT token if successful.
    /// </summary>
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDTO model)
    {
        if (model.Password != model.ConfirmPassword)
            return BadRequest("Passwords do not match.");

        var (succeeded, token, errorMessage) = await _authService.RegisterUser(model);

        if (!succeeded)
            return BadRequest(new { Error = errorMessage });

        return Ok(new { Token = token });
    }

    /// <summary>
    /// Authenticates a user and returns a JWT token.
    /// </summary>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO model)
    {
        var (succeeded, token, errorMessage) = await _authService.LoginUser(model);

        if (!succeeded)
            return Unauthorized(new { Error = errorMessage });

        return Ok(new { Token = token });
    }
}
