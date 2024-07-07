using Coensio.Entities;

namespace Coensio.Models;

public class FreeTextQuestionAnswerRequest
{
    public int TestId { get; set; }
    public int FreeTextQuestionId { get; set; }
    public string? Answer { get; set; }
}
