using Coensio.Models;
using Coensio.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Coensio.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class QuestionController : ControllerBase
{
    private readonly IQuestionService _questionService;
    public QuestionController(IQuestionService questionService)
    {
        _questionService = questionService;
    }

    [HttpGet("CodingQuestion/{id}")]
    public IActionResult GetCodingQuestionAsync(int id)
    {
        return Ok(_questionService.GetCodingQuestion(id));
    }

    [HttpPost("CodingQuestion")]
    public async Task<IActionResult> CreateCodingQuestionAsync([FromBody] CodingQuestionCreateRequest request)
    {
        var id = await _questionService.CreateCodingQuestionAsync(request);

        return CreatedAtAction(nameof(GetCodingQuestionAsync), new { id }, new { id });
    }

    [HttpGet("FreeTextQuestion/{id}")]
    public IActionResult GetFreeTextQuestionAsync(int id)
    {
        return Ok(_questionService.GetFreeTextQuestion(id));
    }

    [HttpPost("FreeTextQuestion")]
    public async Task<IActionResult> CreateFreeTextQuestionAsync([FromBody] FreeTextQuestionCreateRequest request)
    {
        var id = await _questionService.CreateFreeTextQuestionAsync(request);

        return CreatedAtAction(nameof(GetFreeTextQuestionAsync), new { id }, new { id });
    }
}
