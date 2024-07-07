using Coensio.Contexts;
using Coensio.Entities;

namespace Coensio.Repositories;

public class AnswerRepository : IAnswerRepository
{
    private readonly TestContext _testContext;
    public AnswerRepository(TestContext testContext)
    {
        _testContext = testContext;
    }

    public async Task<int> SubmitCodingQuestionAnswerAsync(CodingQuestionUserAnswer answer)
    {
        await _testContext.CodingQuestionUserAnswers.AddAsync(answer);
        await _testContext.SaveChangesAsync();

        return answer.Id;
    }

    public async Task<int> SubmitFreeTextQuestionAnswerAsync(FreeTextQuestionUserAnswer answer)
    {
        await _testContext.FreeTextQuestionUserAnswers.AddAsync(answer);
        await _testContext.SaveChangesAsync();

        return answer.Id;
    }
}

