using System.ComponentModel.DataAnnotations;

namespace Coensio.Entities;

public class CodingQuestion
{
    public int Id { get; set; }
    public DateTimeOffset Created { get; set; }
    public List<Test>? Tests { get; set; }
    [Required]
    public string? Text { get; set; }
    [Required]
    public string? UnitTests { get; set; }
}
