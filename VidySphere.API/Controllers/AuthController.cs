using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VidySphere.Application.DTOs;
using VidySphere.Application.Services;
using VidySphere.Domain.Entities;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;
    private readonly UserService _userService;

    public AuthController(AuthService authService, UserService userService)
    {
        _authService = authService;
        _userService = userService;
    }

    // ✅ Register
    [HttpPost("register")]
    
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        await _userService.Register(request);

        return Ok(new
        {
            message = "User registered successfully"
        });
    }

    // ✅ Login
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var user = await _userService.Login(request.Email, request.Password);

        if (user == null)
            return Unauthorized("Invalid credentials");

        var token = _authService.GenerateToken(user);

        return Ok(new
        {
            token,
            user = new
            {
                user.Id,
                user.Name,
                user.Email,
                user.Role
            }
        });
    }


    [Authorize(Roles = "Admin")]
    [HttpGet("all-users")]
    public IActionResult GetAllUsers()
    {
        return Ok("Only Admin can access");
    }
}