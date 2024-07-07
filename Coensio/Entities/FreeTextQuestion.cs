using System.ComponentModel.DataAnnotations;

namespace Coensio.Entities;

public class FreeTextQuestion
{
    public int Id { get; set; }
    public DateTimeOffset Created { get; set; }
    [Required]
    public string? Text { get; set; }
    public List<Test>? Tests { get; set; }
    [Required]
    public string? SampleAnswer { get; set; }
}
