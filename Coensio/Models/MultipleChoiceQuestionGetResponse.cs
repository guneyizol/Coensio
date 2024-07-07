using System.ComponentModel.DataAnnotations;

namespace Coensio.Models;

public class MultipleChoiceQuestionGetResponse
{
    public int Id { get; set; }
    public DateTimeOffset Created { get; set; }
    public string? Text { get; set; }
    public char Answer { get; set; }
    public string? Error { get; set; }
}
