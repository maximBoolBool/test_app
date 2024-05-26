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
    [JsonProperty("survey_id")]
    public long SurveyId { get; set; }
    
    /// <summary>
    ///     Id вопроса
    /// </summary>
    [JsonProperty("question_id")]
    public long QuestionId { get; set; }
    
    /// <summary>
    ///     Id интервью
    /// </summary>
    [JsonProperty("user_id")]
    public long InterviewId { get; set; }

    /// <summary>
    ///     Варианты выбранных ответов
    /// </summary>
    [JsonProperty("answer_ids")]
    public long[] AnswerIds { get; set; }
}