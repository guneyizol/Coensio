using Coensio.Entities;

namespace Coensio.Repositories;

public interface ITestRepository
{
    Task CreateAsync(Test test);
    Test? Get(int id);
}
