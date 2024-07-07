using System.ComponentModel.DataAnnotations;

namespace Coensio.Models;

public class User
{
    [EmailAddress]
    public string? Email { get; set; }
}
