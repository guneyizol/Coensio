using System.ComponentModel.DataAnnotations;

namespace Coensio.Models;

public class TestGetResponse
{
    public int Id { get; set; }
    public string? UserEmail { get; set; }
    public int Score { get; set; }
    public string? Status { get; set; }
    public DateTimeOffset Created { get; set; }
    public string? Error { get; set; }
}
