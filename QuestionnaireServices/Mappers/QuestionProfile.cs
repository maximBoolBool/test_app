using AutoMapper;
using QuestionnaireEntities.Entities;
using QuestionnaireServices.Models;

namespace QuestionnaireServices.Mappers;

public class QuestionProfile : Profile
{
    public QuestionProfile()
    {
        CreateMap<QuestionEntity, QuestionResponse>()
            .ForMember(dest => dest.Id, m => m.MapFrom(src => src.Id))
            .ForMember(dest => dest.Question, m => m.MapFrom(src => src.Question))
            .ForMember(dest => dest.IsRequired, m => m.MapFrom(src => src.IsRequired))
            .ForMember(dest => dest.IsMultiChoice, m => m.MapFrom(src => src.IsMultiChoice))
            .ForMember(dest => dest.Answers, m => m.MapFrom(src => src.Answers));

        CreateMap<AnswerEntity, AnswerModel>()
            .ForMember(dest => dest.Id, m => m.MapFrom(src => src.Id))
            .ForMember(dest => dest.Response, m => m.MapFrom(src => src.Response));
    }
}