using QuestionnaireEntities.Repositories;
using QuestionnaireEntities.Repositories.Impl;

namespace QuestionnaireEntities;

public class SurveyDbWorker : ISurveyDbWorker, IDisposable
{
    #region Fieldes

    private readonly SurveyDbContext _context;

    #endregion
    
    #region Repositories

    /// <inheritdoc />
    public IAncwerRepository Ancwers { get; }
    
    /// <inheritdoc />
    public IInteviewRepository Inteviews { get; }
    
    /// <inheritdoc />
    public IQuestionRepository Questions { get; }
    
    /// <inheritdoc />
    public IResultRepository Results { get; }
    
    /// <inheritdoc />
    public ISurveyRepository Surveys { get; }

    #endregion

    #region .ctor

    /// .ctor
    public SurveyDbWorker(SurveyDbContext context)
    {
        _context = context;
        Ancwers = new AnswerRepository(context);
        Inteviews = new InteviewRepository(context);
        Questions = new QuestionRepository(context);
        Results = new ResultRepository(context);
        Surveys = new SurveyRepository(context);
    }

    #endregion

    #region Public Methodes

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
        => await _context.SaveChangesAsync(cancellationToken);


    #endregion
    
    public void Dispose()
    {
        _context.Dispose();
    }
}