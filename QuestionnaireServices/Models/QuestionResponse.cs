using Newtonsoft.Json;

namespace QuestionnaireServices.Models;

/// <summary>
///     Модель вопроса с ответами
/// </summary>
public class QuestionResponse
{
    /// <summary>
    ///     Id
    /// </summary>
    [JsonProperty("id")]
    public long Id { get; set; }
    
    /// <summary>
    ///     Вопрос
    /// </summary>
    [JsonProperty("question")]
    public string Question { get; set; }
    
    /// <summary>
    ///     True если ответ обязательный
    /// </summary>
    [JsonProperty("is_required")]
    public bool IsRequired { get; set; }
    
    /// <summary>
    ///     True если доступно
    ///     несколько вариантов ответа
    /// </summary>
    [JsonProperty("is_multi_choice")]
    public bool IsMultiChoice { get; set; }
    
    /// <summary>
    ///     Варианты ответов
    /// </summary>
    [JsonProperty("answers")]
    public List<AnswerModel> Answers { get; set; }
}