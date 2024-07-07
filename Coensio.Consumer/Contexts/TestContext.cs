using Coensio.Consumer.Entities;

using Microsoft.EntityFrameworkCore;

namespace Coensio.Contexts;

public class TestContext : DbContext
{
    public DbSet<Test> Tests => Set<Test>();
    public DbSet<CodingQuestionUserAnswer> CodingQuestionUserAnswers => Set<CodingQuestionUserAnswer>();
    public DbSet<FreeTextQuestionUserAnswer> FreeTextQuestionUserAnswers => Set<FreeTextQuestionUserAnswer>();
    public DbSet<MultipleChoiceQuestionUserAnswer> McqUserAnswers => Set<MultipleChoiceQuestionUserAnswer>();

    public TestContext(DbContextOptions<TestContext> opts) : base(opts)
    {
        
    }
}
