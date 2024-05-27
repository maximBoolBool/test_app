using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace QuestionnaireServices.Models;

/// <summary>
///     Ответ содержащий информацию про следующий вопрос
/// </summary>
public class NextQuestionResult
{
    /// <summary>
    ///     Id вопроса
    /// </summary>
    [JsonProperty("question_id")]
    public long? QuestionId { get; set; }
    
    /// <summary>
    ///     Номер вопроса в анкете
    /// </summary>
    [JsonProperty("question_number")]
    public int QuestionNumber { get; set; }
    
    /// <summary>
    ///     Общее количество вопросов в анкете
    /// </summary>
    [JsonProperty("question_count")]
    public int QuestionCount { get; set; }
    
    /// <summary>
    ///     Достигли ли конца опроса
    /// </summary>
    [JsonProperty("is_next_exist")]
    public bool IsEnd { get; set; }
    
    /// <summary>
    ///     Id интервью
    /// </summary>
    [JsonProperty("interview_id")]
    public long InterviewId { get; set; }
}