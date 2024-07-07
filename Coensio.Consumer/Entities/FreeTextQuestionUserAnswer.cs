namespace Coensio.Consumer.Entities;

public class FreeTextQuestionUserAnswer
{
    public int Id { get; set; }
    public DateTimeOffset Created { get; set; }
    public int TestId { get; set; }
    public Test? Test { get; set; }
    public string? Answer { get; set; }
    public int Score { get; set; }
}
