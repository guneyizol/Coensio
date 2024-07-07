namespace Coensio.Models;

public class CodingQuestionAnswerRequest
{
    public int TestId { get; set; }
    public int CodingQuestionId { get; set; }
    public string? Answer { get; set; }
}
