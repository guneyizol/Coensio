using AutoMapper;

using Coensio.Entities;
using Coensio.Models;

namespace Coensio.MapperProfiles;

public class TestProfile : Profile
{
    public TestProfile()
    {
        CreateMap<TestCreateRequest, Test>();
        CreateMap<Test, TestCreateResponse>();

        CreateMap<CodingQuestionCreateRequest, CodingQuestion>();
        CreateMap<CodingQuestion, CodingQuestionCreateResponse>();

        CreateMap<Test, TestGetResponse>();

        CreateMap<FreeTextQuestionCreateRequest, FreeTextQuestion>();

        CreateMap<CodingQuestion, CodingQuestionGetResponse>();
        CreateMap<FreeTextQuestion, FreeTextQuestionGetResponse>();
        CreateMap<MultipleChoiceQuestion, MultipleChoiceQuestionGetResponse>();
    }
}
