using Coensio.Entities;
using System.ComponentModel.DataAnnotations;

namespace Coensio.Models;

public class CodingQuestionCreateRequest
{
    [Required]
    public string? Text { get; set; }
    [Required]
    public string? UnitTests { get; set; }
}
