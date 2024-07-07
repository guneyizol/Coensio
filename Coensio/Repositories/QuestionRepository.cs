using AutoMapper;

using Coensio.Contexts;
using Coensio.Entities;

namespace Coensio.Repositories;

public class QuestionRepository : IQuestionRepository
{
    private readonly TestContext _testContext;
    private readonly IMapper _mapper;

    public QuestionRepository(TestContext testContext, IMapper mapper)
    {
        _testContext = testContext;
        _mapper = mapper;
    }

    public CodingQuestion? GetCodingQuestion(int id)
    {
        var question = _testContext.CodingQuestions.Where(q => q.Id == id).FirstOrDefault();
        return question;
    }

    public FreeTextQuestion? GetFreeTextQuestion(int id)
    {
        var question = _testContext.FreeTextQuestions.Where(q => q.Id == id).FirstOrDefault();
        return question;
    }

    public MultipleChoiceQuestion? GetMultipleChoiceQuestion(int id)
    {
        var question = _testContext.MultipleChoiceQuestions.Where(q => q.Id == id).FirstOrDefault();
        return question;
    }

    public async Task<int> CreateCodingQuestionAsync(CodingQuestion codingQuestion)
    {
        await _testContext.AddAsync(codingQuestion);
        await _testContext.SaveChangesAsync();

        return codingQuestion.Id;
    }

    public async Task<int> CreateFreeTextQuestionAsync(FreeTextQuestion freeTextQuestion)
    {
        await _testContext.AddAsync(freeTextQuestion);
        await _testContext.SaveChangesAsync();

        return freeTextQuestion.Id;
    }

    public async Task<int> CreateMultipleChoiceQuestionAsync(FreeTextQuestion multipleChoiceQuestion)
    {
        await _testContext.AddAsync(multipleChoiceQuestion);
        await _testContext.SaveChangesAsync();

        return multipleChoiceQuestion.Id;
    }
}
