using System.Linq.Expressions;
using QuestionnaireEntities.Entities;

namespace QuestionnaireEntities.Repositories;

/// <summary>
///     Репозиторий для работы с сущностями
/// </summary>
public interface IRepository<TEntity> where TEntity : BaseEntity
{
    /// <summary>
    ///     Получить сущность по Id
    /// </summary>
    Task<TEntity?> GetByIdAsync(long id, CancellationToken cancellationToken);

    /// <summary>
    ///     Создать новую сущность в бд 
    /// </summary>
    void Add(TEntity entity);

    Task AddRange(IEnumerable<TEntity> entities);

    /// <summary>
    ///     Получить список сущностей
    /// </summary>
    Task<List<TEntity>> ListAsync(Expression<Func<TEntity, bool>>? filter, CancellationToken cancellationToken);

    /// <summary>
    ///     Созадть запрос для получения сущностей
    /// </summary>
    IQueryable<TEntity> CreateQuery();
}