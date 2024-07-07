using System.ComponentModel.DataAnnotations;

namespace Coensio.Models;

public class CodingQuestionGetResponse
{
    public int Id { get; set; }
    public DateTimeOffset Created { get; set; }
    public string? Text { get; set; }
    public string? UnitTests { get; set; }
    public string? Error { get; set; }
}
