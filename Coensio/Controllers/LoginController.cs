using Coensio.Models;
using Coensio.Services;

using Microsoft.AspNetCore.Mvc;

namespace Coensio.Controllers;
[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{
    private readonly AuthService _authService;

    public LoginController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost(Name = "Login")]
    public async Task<string> Login([FromBody]User user)
    {
        return await _authService.CreateToken(user);
    }
}
