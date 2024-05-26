using AutoMapper;
using QuestionnaireEntities.Entities;
using QuestionnaireServices.Models;

namespace QuestionnaireServices.Mappers;

public class QuestionProfile : Profile
{
    public QuestionProfile()
    {
        CreateMap<QuestionResponse, QuestionEntity>()
            .ForMember(s => s.Answers, m => m.Ignore());

        CreateMap<AnswerModel, AnswerEntity>()
            .ForMember(s => s.Question, m => m.Ignore());
    }
}