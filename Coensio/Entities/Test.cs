using System.ComponentModel.DataAnnotations;

namespace Coensio.Entities;

public class Test
{
    public int Id { get; set; }

    [EmailAddress]
    [Required]
    public string? UserEmail { get; set; }
    public int Score { get; set; }
    public string? Status { get; set; }
    public DateTimeOffset Created {  get; set; }
    public List<CodingQuestion>? CodingQuestions { get; set; }
    public List<FreeTextQuestion>? FreeTextQuestions { get; set; }
    public List<MultipleChoiceQuestion>? MultipleChoiceQuestions { get; set; }
}
