
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace QuestionnaireServices.Models.Requests;

/// <summary>
///     Запрос для сохранения результатов на вопрос
/// </summary>
public class UpplyResultRequest
{
    /// <summary>
    ///     Id опросника
    /// </summary>
    [JsonPropertyName("survey_id")]
    public long SurveyId { get; set; }
    
    /// <summary>
    ///     Id вопроса
    /// </summary>
    [JsonPropertyName("question_id")]
    public long QuestionId { get; set; }
    
    /// <summary>
    ///     Id интервью
    /// </summary>
    [JsonPropertyName("user_id")]
    public long? InterviewId { get; set; }

    /// <summary>
    ///     Варианты выбранных ответов
    /// </summary>
    [JsonPropertyName("answer_ids")]
    public long[] AnswerIds { get; set; }
}