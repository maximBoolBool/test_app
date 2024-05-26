using Microsoft.EntityFrameworkCore;
using QuestionnaireEntities.Entities;

namespace QuestionnaireEntities.Repositories.Impl;

/// <inheritdoc cref="IResultRepository"/>
public class ResultRepository : BaseRepository<ResultEntity>, IResultRepository
{
    /// .ctor
    public ResultRepository(DbContext context) : base(context) { }
}