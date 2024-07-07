using Coensio.Models;

namespace Coensio.Services;

public interface IAnswerService
{
    Task<int> SubmitCodingQuestionAnswerAsync(CodingQuestionAnswerRequest request);
    Task<int> SubmitFreeTextQuestionAnswerAsync(FreeTextQuestionAnswerRequest request);
}
