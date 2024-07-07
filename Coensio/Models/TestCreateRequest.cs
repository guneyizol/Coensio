using System.ComponentModel.DataAnnotations;

namespace Coensio.Models;

public class TestCreateRequest
{
    [Required]
    [EmailAddress]
    public string? UserEmail { get; set; }
    public List<int>? CodingQuestions { get; set; }
    public List<int>? FreeTextQuestions { get; set; }
}
