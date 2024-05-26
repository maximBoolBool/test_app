using Microsoft.EntityFrameworkCore;
using QuestionnaireEntities.Entities;

namespace QuestionnaireEntities.Repositories.Impl;

/// <inheritdoc cref="IAncwerRepository" />
public class AnswerRepository : BaseRepository<AnswerEntity>, IAncwerRepository
{
    /// .ctor
    public AnswerRepository(DbContext context) : base(context) { }
}