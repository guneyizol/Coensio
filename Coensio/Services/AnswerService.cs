using Coensio.Entities;
using Coensio.Models;
using Coensio.Repositories;

namespace Coensio.Services;

public class AnswerService : IAnswerService
{
    private readonly IAnswerRepository _answerRepository;

    public AnswerService(IAnswerRepository answerRepository)
    {
        _answerRepository = answerRepository;
    }

    public async Task<int> SubmitCodingQuestionAnswerAsync(CodingQuestionAnswerRequest request)
    {
        var score = CalculateCodingQuestionScore(request.Answer ?? string.Empty);

        var answer = new CodingQuestionUserAnswer
        {
            TestId = request.TestId,
            CodingQuestionId = request.CodingQuestionId,
            Answer = request.Answer,
            Score = score,
        };

        var id = await _answerRepository.SubmitCodingQuestionAnswerAsync(answer);

        return id;
    }

    public async Task<int> SubmitFreeTextQuestionAnswerAsync(FreeTextQuestionAnswerRequest request)
    {
        var score = CalculateFreeTextQuestionScore(request.Answer ?? string.Empty);

        var answer = new FreeTextQuestionUserAnswer
        {
            TestId = request.TestId,
            FreeTextQuestionId = request.FreeTextQuestionId,
            Answer = request.Answer,
            Score = score,
        };

        var id = await _answerRepository.SubmitFreeTextQuestionAnswerAsync(answer);

        return id;
    }

    public int CalculateCodingQuestionScore(string answer)
    {
        var rand  = new Random();
        return rand.Next(5);
    }

    public int CalculateFreeTextQuestionScore(string answer)
    {
        var rand = new Random();
        return rand.Next(5);
    }
    public int CalculateMultipleChoiceQuestionScore(char answer)
    {
        var rand = new Random();
        return rand.Next(5);
    }
}
