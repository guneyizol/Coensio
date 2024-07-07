using System.ComponentModel.DataAnnotations;

namespace Coensio.Models;

public class FreeTextQuestionCreateRequest
{
    [Required]
    public string? Text { get; set; }
    [Required]
    public string? SampleAnswer { get; set; }
}
