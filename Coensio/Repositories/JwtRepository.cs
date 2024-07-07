using Coensio.Models;
using Coensio.Repositories;

using StackExchange.Redis;

namespace Coensio.Repository;

public class JwtRepository : IJwtRepository
{
    private readonly IDatabase _redis;

    public JwtRepository(IConnectionMultiplexer connMux)
    {
        _redis = connMux.GetDatabase();
    }

    public async Task StoreJwt(User user, string jwt)
    {
        await _redis.HashSetAsync("jwts", user.Email, jwt);
    }
}
