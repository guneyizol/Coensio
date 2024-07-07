using Coensio.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Hosting;

using System.Reflection.Metadata;

namespace Coensio.Contexts;

public class TestContext : DbContext
{
    public DbSet<Test> Tests => Set<Test>();
    public DbSet<CodingQuestion> CodingQuestions => Set<CodingQuestion>();
    public DbSet<CodingQuestionUserAnswer> CodingQuestionUserAnswers => Set<CodingQuestionUserAnswer>();
    public DbSet<FreeTextQuestion> FreeTextQuestions => Set<FreeTextQuestion>();
    public DbSet<FreeTextQuestionUserAnswer> FreeTextQuestionUserAnswers => Set<FreeTextQuestionUserAnswer>();
    public DbSet<MultipleChoiceQuestion> MultipleChoiceQuestions => Set<MultipleChoiceQuestion>();
    public DbSet<MultipleChoiceQuestionUserAnswer> McqUserAnswers => Set<MultipleChoiceQuestionUserAnswer>();
    public TestContext(DbContextOptions<TestContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Test>()
            .Property(b => b.Created)
            .HasDefaultValueSql("now()");

        modelBuilder.Entity<CodingQuestion>()
            .Property(b => b.Created)
            .HasDefaultValueSql("now()");

        modelBuilder.Entity<CodingQuestionUserAnswer>()
            .Property(b => b.Created)
            .HasDefaultValueSql("now()");

        modelBuilder.Entity<FreeTextQuestion>()
            .Property(b => b.Created)
            .HasDefaultValueSql("now()");

        modelBuilder.Entity<FreeTextQuestionUserAnswer>()
            .Property(b => b.Created)
            .HasDefaultValueSql("now()");

        modelBuilder.Entity<MultipleChoiceQuestion>()
            .Property(b => b.Created)
            .HasDefaultValueSql("now()");

        modelBuilder.Entity<MultipleChoiceQuestionUserAnswer>()
            .Property(b => b.Created)
            .HasDefaultValueSql("now()");
    }
}

public class TestContextFactory : IDesignTimeDbContextFactory<TestContext>
{
    public TestContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TestContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=coensio;Username=postgres;Password=mypassword123;")
            .UseSnakeCaseNamingConvention();

        return new TestContext(optionsBuilder.Options);
    }
}
