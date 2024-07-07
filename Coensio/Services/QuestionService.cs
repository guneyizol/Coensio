using AutoMapper;

using Coensio.Entities;
using Coensio.Models;
using Coensio.Repositories;

namespace Coensio.Services;

public class QuestionService : IQuestionService
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;
    public QuestionService(IQuestionRepository questionRepository, IMapper mapper)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
    }

    public CodingQuestionGetResponse GetCodingQuestion(int id)
    {
        var question = _questionRepository.GetCodingQuestion(id);
        if (question is null)
        {
            return new CodingQuestionGetResponse
            {
                Error = $"Coding Question with id: {id} does not exist."
            };
        }

        return _mapper.Map<CodingQuestionGetResponse>(question);
    }

    public async Task<int> CreateCodingQuestionAsync(CodingQuestionCreateRequest request)
    {
        var codingQuestion = _mapper.Map<CodingQuestion>(request);

        var id = await _questionRepository.CreateCodingQuestionAsync(codingQuestion);

        return id;
    }

    public FreeTextQuestionGetResponse GetFreeTextQuestion(int id)
    {
        var question = _questionRepository.GetFreeTextQuestion(id);
        if (question is null)
        {
            return new FreeTextQuestionGetResponse
            {
                Error = $"Free Text Question with id: {id} does not exist."
            };
        }

        return _mapper.Map<FreeTextQuestionGetResponse>(question);
    }

    public MultipleChoiceQuestionGetResponse GetMultipleChoiceQuestion(int id)
    {
        var question = _questionRepository.GetMultipleChoiceQuestion(id);
        if (question is null)
        {
            return new MultipleChoiceQuestionGetResponse
            {
                Error = $"Free Text Question with id: {id} does not exist."
            };
        }

        return _mapper.Map<MultipleChoiceQuestionGetResponse>(question);
    }

    public async Task<int> CreateFreeTextQuestionAsync(FreeTextQuestionCreateRequest request)
    {
        var freeTextQuestion = _mapper.Map<FreeTextQuestion>(request);

        var id = await _questionRepository.CreateFreeTextQuestionAsync(freeTextQuestion);

        return id;
    }
}
