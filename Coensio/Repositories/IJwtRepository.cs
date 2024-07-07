using Coensio.Models;

namespace Coensio.Repositories;

public interface IJwtRepository
{
    Task StoreJwt(User user, string jwt);
}
