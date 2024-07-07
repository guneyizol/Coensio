using Coensio.Models;
using Coensio.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Net;

namespace Coensio.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class TestController : ControllerBase
{
    private readonly ITestService _testService;
    public TestController(ITestService testService)
    {
        _testService = testService;
    }

    [HttpGet("{id}")]
    public IActionResult GetAsync(int id)
    {
        return Ok(_testService.Get(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] TestCreateRequest test)
    {
        var response = await _testService.CreateAsync(test);
        if (response.Error is not null)
        {
            return Problem(response.Error, statusCode: (int)HttpStatusCode.UnprocessableEntity);
        }

        return CreatedAtAction(nameof(GetAsync), new { id = response.Id }, response);
    }

    [HttpPost("Calculate/{id}")]
    public async Task<IActionResult> SendTestCalculationEventAsync(int id)
    {
        await _testService.SendTestCalculationEventAsync(id);

        return Ok(new { message = "Event sent." });
    }
}
