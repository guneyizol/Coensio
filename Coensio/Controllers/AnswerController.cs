using Coensio.Models;
using Coensio.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Coensio.Controllers;
[ApiController]
[Route("[controller]")]
[Authorize]
public class AnswerController : ControllerBase
{
    private readonly IAnswerService _answerService;
    public AnswerController(IAnswerService answerService)
    {
        _answerService = answerService;
    }

    [HttpGet("CodingQuestion/{id}")]
    public IActionResult GetCodingQuestionAnswerAsync(int id)
    {
        return Ok();
    }

    [HttpPost("CodingQuestion")]
    public async Task<IActionResult> SubmitCodingQuestionAnswerAsync([FromBody] CodingQuestionAnswerRequest request)
    {
        var id = await _answerService.SubmitCodingQuestionAnswerAsync(request);
        return CreatedAtAction(nameof(GetCodingQuestionAnswerAsync), new { id }, new { id });
    }


    [HttpGet("FreeTextQuestion/{id}")]
    public IActionResult GetFreeTextQuestionAnswerAsync(int id)
    {
        return Ok();
    }

    [HttpPost("FreeTextQuestion")]
    public async Task<IActionResult> SubmitFreeTextQuestionAnswerAsync([FromBody] FreeTextQuestionAnswerRequest request)
    {
        var id = await _answerService.SubmitFreeTextQuestionAnswerAsync(request);
        return CreatedAtAction(nameof(GetCodingQuestionAnswerAsync), new { id }, new { id });
    }
}
