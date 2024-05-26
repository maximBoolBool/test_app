using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using QuestionnaireEntities.Entities;

namespace QuestionnaireEntities.Repositories;

/// <summary>
///     Базовый репозиторий
/// </summary>
public abstract class BaseRepository<TEntity> : IRepository<TEntity> 
    where TEntity : BaseEntity
{
    #region Fieldes

    private readonly DbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    #endregion
    
    #region .ctor

    /// .ctor
    public BaseRepository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    #endregion
    
    #region public Methodes

    /// <inheritdoc />
    public async Task<TEntity?> GetByIdAsync(long id, CancellationToken cancellationToken) =>
        await _dbSet.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

    /// <inheritdoc />
    public void Add(TEntity entity) =>
        Task.FromResult(_dbSet.Add(entity));

    /// <inheritdoc />
    public async Task AddRange(IEnumerable<TEntity> entities)
    {   
        _dbSet.AddRange(entities);
    }
      
    /// <inheritdoc />
    public async Task<List<TEntity>> ListAsync(
        Expression<Func<TEntity, bool>>? filter,
        CancellationToken cancellationToken) =>
        filter != null? await _dbSet.Where(filter).ToListAsync(cancellationToken) : await _dbSet.ToListAsync(cancellationToken) ;

    /// <inheritdoc />
    public IQueryable<TEntity> CreateQuery() =>
        _dbSet.AsQueryable();

    #endregion
}