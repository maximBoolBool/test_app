using Microsoft.EntityFrameworkCore;
using QuestionnaireEntities.Entities;

namespace QuestionnaireEntities.Repositories.Impl;

/// <inheritdoc cref="IInteviewRepository"/>
public class InteviewRepository : BaseRepository<InterviewEntity>, IInteviewRepository
{
    /// .ctor
    public InteviewRepository(DbContext context) : base(context) { }
}