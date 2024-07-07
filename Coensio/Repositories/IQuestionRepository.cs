using Coensio.Entities;

namespace Coensio.Repositories;

public interface IQuestionRepository
{
    CodingQuestion? GetCodingQuestion(int id);
    FreeTextQuestion? GetFreeTextQuestion(int id);
    MultipleChoiceQuestion? GetMultipleChoiceQuestion(int id);
    Task<int> CreateCodingQuestionAsync(CodingQuestion request);
    Task<int> CreateFreeTextQuestionAsync(FreeTextQuestion freeTextQuestion);
    Task<int> CreateMultipleChoiceQuestionAsync(FreeTextQuestion multipleChoiceQuestion);
}
