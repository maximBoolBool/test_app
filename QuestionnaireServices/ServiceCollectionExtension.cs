using Microsoft.Extensions.DependencyInjection;
using QuestionnaireServices.Mappers;
using QuestionnaireServices.Services;
using QuestionnaireServices.Services.Impl;

namespace QuestionnaireServices;

public static class ServiceCollectionExtension
{
    public static void AddQuestionnaireServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(QuestionProfile));
        services.AddScoped<IQuestionnaireService, QuestionnaireService>();
    }
}