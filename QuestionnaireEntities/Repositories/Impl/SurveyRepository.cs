using Microsoft.EntityFrameworkCore;
using QuestionnaireEntities.Entities;

namespace QuestionnaireEntities.Repositories.Impl;

/// <inheritdoc cref="ISurveyRepository"/>
public class SurveyRepository : BaseRepository<SurveyEntity>, ISurveyRepository
{
    /// .ctor
    public SurveyRepository(DbContext context) : base(context) { }
}