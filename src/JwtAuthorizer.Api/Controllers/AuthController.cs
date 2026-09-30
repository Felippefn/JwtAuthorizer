using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    public AuthController(IUserService userService)
    {
        _userService = userService;
    }


    [HttpPost("signup")]
    public async Task<IActionResult> Signup(SignupRequest request)
    {
        if

        var token = await _userService.SignupAsync(request.EmailAddress, request.Password);
        return Ok(new { Message = "User created successfully." });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var token = await _userService.LoginAsync(request.Username, request.Password);
        if (token is null)
            return Unauthorized();

        return Ok(new { Token = token });
    }

    [Authorize]
    [HttpGet("me")]
    public IActionResult Me()
    {
        var username = User.FindFirst(ClaimTypes.Name)?.Value;
        var role = User.FindFirst(ClaimTypes.Role)?.Value;

        return Ok(new { Message = "User information retrieved successfully.", Username = username, Role = role });
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("me2")]
    public IActionResult Me2()
    {
        var username = User.FindFirst(ClaimTypes.Name)?.Value;
        var role = User.FindFirst(ClaimTypes.Role)?.Value;

        return Ok(new { Message = "User information retrieved successfully.", Username = username, Role = role });
    }
}
