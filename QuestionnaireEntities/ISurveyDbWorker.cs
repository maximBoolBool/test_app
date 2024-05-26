using QuestionnaireEntities.Repositories;

namespace QuestionnaireEntities;

/// <summary>
///     Воркер для работы с бд опросов
/// </summary>
public interface ISurveyDbWorker
{
    /// <summary>
    ///     Ответы
    /// </summary>
    IAncwerRepository Ancwers { get; }
    
    /// <summary>
    ///     Интервью
    /// </summary>
    IInteviewRepository Inteviews { get; }
    
    /// <summary>
    ///     Вопросы
    /// </summary>
    IQuestionRepository Questions { get; }
    
    /// <summary>
    ///     Результаты
    /// </summary>
    IResultRepository Results { get; }
    
    /// <summary>
    ///     Опросы
    /// </summary>
    ISurveyRepository Surveys { get; }

    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}