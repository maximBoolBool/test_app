using QuestionnaireServices.Models;
using QuestionnaireServices.Models.Requests;

namespace QuestionnaireServices.Services;

/// <summary>
///     Сервис для работы опросами
/// </summary>
public interface IQuestionnaireService
{
    /// <summary>
    ///     Получить вопрос
    /// </summary>
    Task<QuestionResponse> GetQuestionByIdAsync(
        long id,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Сохранить результат вопроса
    /// </summary>
    Task<NextQuestionResult> SaveQuestionResult(
        UpplyResultRequest request,
        CancellationToken cancellationToken = default);
}