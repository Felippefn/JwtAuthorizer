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
    public async Task<IActionResult> Signup([FromBody] SignupRequest request)
    {
        var token = await _userService.SignupAsync(new SignupData(
            Email: request.EmailAddress,
            FirstName: request.FirstName,
            LastName: request.LastName,
            PrimaryPhoneNumber: request?.PrimaryPhoneNumber,
            PasswordHash: request.Password
        ));
        return Created("User created successfully.", new { User = request.EmailAddress });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var token = await _userService.LoginAsync(request.EmailAddress, request.Password);
        if (token is null)
            return Unauthorized();

        return Ok(new { Token = token });
    }

    [Authorize]
    [HttpGet("me")]
    public IActionResult Me()
    {
        var email = User.FindFirst(ClaimTypes.Email)?.Value;
        var role = User.FindFirst(ClaimTypes.Role.ToString())?.Value;

        return Ok(new { Message = "User information retrieved successfully.", Email = email, Role = role });
    }

    [Authorize(Roles = "ADMIN")]
    [HttpGet("me2")]
    public IActionResult Me2()
    {
        var email = User.FindFirst(ClaimTypes.Email)?.Value;
        var role = User.FindFirst(ClaimTypes.Role)?.Value;

        return Ok(new { Message = "User information retrieved successfully.", Email = email, Role = role });
    }
}
