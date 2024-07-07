using AutoMapper;

using Coensio.Contract;
using Coensio.Entities;
using Coensio.Models;
using Coensio.Repositories;

using EntityFramework.Exceptions.Common;

using MassTransit;
using MassTransit.Transports;

using static System.Net.Mime.MediaTypeNames;

namespace Coensio.Services;

public class TestService : ITestService
{
    private const string SendEndpoint = "rabbitmq://rabbitmq/coensio";
    private readonly ITestRepository _repository;
    private readonly IMapper _mapper;
    private readonly ISendEndpointProvider _sendEndpointProvider;
    public TestService(ITestRepository testRepository, IMapper mapper, ISendEndpointProvider sendEndpointProvider)
    {
        _repository = testRepository;
        _mapper = mapper;
        _sendEndpointProvider = sendEndpointProvider;
    }

    public async Task<TestCreateResponse> CreateAsync(TestCreateRequest testCreate)
    {
        var test = new Test
        {
            UserEmail = testCreate.UserEmail,
            Status = "In progress"
        };

        if (testCreate.CodingQuestions is not null && testCreate.CodingQuestions.Count() != 0)
        {
            test.CodingQuestions = (testCreate.CodingQuestions?.Select(id => new CodingQuestion { Id = id })
               ?? Enumerable.Empty<CodingQuestion>()).ToList();
        }

        if (testCreate.FreeTextQuestions is not null && testCreate.FreeTextQuestions.Count() != 0)
        {
            test.FreeTextQuestions = (testCreate.FreeTextQuestions?.Select(id => new FreeTextQuestion { Id = id })
               ?? Enumerable.Empty<FreeTextQuestion>()).ToList();
        }

        try
        {
            await _repository.CreateAsync(test);
        }
        catch (ReferenceConstraintException ex)
        {
            return new TestCreateResponse
            {
                Error = ex.Message,
            };
        }

        return _mapper.Map<TestCreateResponse>(test);
    }

    public TestGetResponse Get(int id)
    {
        var test = _repository.Get(id);

        if (test is null)
        {
            return new TestGetResponse
            {
                Error = $"Test with id: {id} does not exist."
            };
        }

        return _mapper.Map<TestGetResponse>(test);
    }

    public async Task SendTestCalculationEventAsync(int id)
    {
        var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri(SendEndpoint));
        await endpoint.Send(new TestCalculationEvent { Id = id });
    }
}
