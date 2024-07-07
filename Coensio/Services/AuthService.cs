using Coensio.Models;
using Coensio.Repositories;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

using System.Security.Claims;
using System.Text;

namespace Coensio.Services;

public class AuthService
{
    private readonly JsonWebTokenHandler _jwtHandler;
    private readonly JwtOptions _jwtOptions;
    private readonly IJwtRepository _jwtRepository;
    public AuthService
        (
            JsonWebTokenHandler jwtHandler,
            IOptions<JwtOptions> jwtOptions,
            IJwtRepository jwtRepository
        )
    {
        _jwtHandler = jwtHandler;
        _jwtOptions = jwtOptions.Value;
        _jwtRepository = jwtRepository;
    }
    public async Task<string> CreateToken(User user)
    {
        var key = Encoding.UTF8.GetBytes(_jwtOptions.Secret);

        var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            SigningCredentials = credentials,
            Expires = DateTime.UtcNow.AddMinutes(30),
            Subject = new ClaimsIdentity([new Claim(ClaimTypes.Email, user.Email ?? string.Empty)]),
            Issuer = _jwtOptions.Issuer,
            Audience = _jwtOptions.Audience,
        };

        var jwt = _jwtHandler.CreateToken(tokenDescriptor);

        await _jwtRepository.StoreJwt(user, jwt);

        return jwt;
    }
}
