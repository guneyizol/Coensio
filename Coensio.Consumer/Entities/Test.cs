using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Coensio.Consumer.Entities;
public class Test
{
    public int Id { get; set; }
    public string? UserEmail { get; set; }
    public int Score { get; set; }
    public string? Status { get; set; }
    public DateTimeOffset Created { get; set; }
}
