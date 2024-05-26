using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace QuestionnaireEntities;

/// <summary>
///     Метод расширения для провайдера сервисов
/// </summary>
public static class ServiceProviderExtension
{
    /// <summary>
    ///     Применить миграции
    /// </summary>
    public static void ApplyMigration<TContext>(this IServiceProvider provider)
        where TContext : DbContext
    {
        using var scope = provider.CreateScope();
        var context = scope.ServiceProvider.GetService<TContext>();
        context.Database.Migrate();
    }
}