using CinemaHub_BLL.Services.Users;
using CinemaHub_BLL.DTO.Login;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using CinemaHub_BLL.wrapping;
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly iUserService _userService;

    public AuthController(iUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginRespondDto>> Login([FromBody] LoginRequestDTO loginRequest)
    {
        LoginRespondDto loginRespondDto = new LoginRespondDto();
        LoginRespondDto user = await _userService.AuthenticateUserAsync(loginRequest.Username, loginRequest.Password);
        if (user == null) return Unauthorized("Invalid username or password");

        return Ok(user); // Includes Cinema information in UserRequestDto
    }
}
