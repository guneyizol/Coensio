using System.ComponentModel.DataAnnotations;

namespace Coensio.Models;

public class FreeTextQuestionGetResponse
{
    public int Id { get; set; }
    public DateTimeOffset Created { get; set; }
    [Required]
    public string? Text { get; set; }
    [Required]
    public string? SampleAnswer { get; set; }
    public string? Error { get; set; }
}
