using Coensio.Contexts;
using Coensio.Entities;

namespace Coensio.Repositories;

public class TestRepository : ITestRepository
{
    private readonly TestContext _context;
    public TestRepository(TestContext testContext)
    {
        _context = testContext;
    }
    public async Task CreateAsync(Test test)
    {
        _context.Attach(test);

        await _context.SaveChangesAsync();
    }

    public Test? Get(int id)
    {
        return _context.Tests.Where(t => t.Id == id).FirstOrDefault();
    }
}
