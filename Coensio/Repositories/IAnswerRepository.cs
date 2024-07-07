using Coensio.Entities;

namespace Coensio.Repositories;

public interface IAnswerRepository
{
    Task<int> SubmitCodingQuestionAnswerAsync(CodingQuestionUserAnswer answer);
    Task<int> SubmitFreeTextQuestionAnswerAsync(FreeTextQuestionUserAnswer answer);
}
