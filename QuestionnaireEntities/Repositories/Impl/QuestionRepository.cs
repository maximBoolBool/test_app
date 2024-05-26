using Microsoft.EntityFrameworkCore;
using QuestionnaireEntities.Entities;

namespace QuestionnaireEntities.Repositories.Impl;

/// <inheritdoc cref="IQuestionRepository"/>
public class QuestionRepository : BaseRepository<QuestionEntity>, IQuestionRepository
{
    /// .ctor
    public QuestionRepository(DbContext context) : base(context) { }
}