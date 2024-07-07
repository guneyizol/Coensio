using Coensio.Models;

namespace Coensio.Services;

public interface IQuestionService
{
    CodingQuestionGetResponse GetCodingQuestion(int id);
    FreeTextQuestionGetResponse GetFreeTextQuestion(int id);
    MultipleChoiceQuestionGetResponse GetMultipleChoiceQuestion(int id);
        Task<int> CreateCodingQuestionAsync(CodingQuestionCreateRequest request);
    Task<int> CreateFreeTextQuestionAsync(FreeTextQuestionCreateRequest request);
}
