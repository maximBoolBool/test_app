using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuestionnaireEntities.Configure;

namespace QuestionnaireEntities;

public static class ServiceCollectionExtension
{
    public static void AddQuestionnarieEntities(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(DbConfigsKeys.DbConnectionKey);

        services.AddDbContext<SurveyDbContext>(options => options.UseNpgsql(connectionString));
        services.AddScoped<ISurveyDbWorker, SurveyDbWorker>();
    }
}