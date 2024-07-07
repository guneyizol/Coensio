namespace Coensio.Entities;

public class CodingQuestionUserAnswer
{
    public int Id { get; set; }
    public DateTimeOffset Created { get; set; }
    public int TestId { get; set; }
    public Test? Test { get; set; }
    public int CodingQuestionId { get; set; }
    public CodingQuestion? CodingQuestion { get; set; }
    public string? Answer { get; set; }
    public int Score { get; set; }
}
