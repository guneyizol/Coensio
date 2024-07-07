using Coensio.Models;

namespace Coensio.Services;

public interface ITestService
{
    Task<TestCreateResponse> CreateAsync(TestCreateRequest test);
    TestGetResponse Get(int id);
    Task SendTestCalculationEventAsync(int id);
}
