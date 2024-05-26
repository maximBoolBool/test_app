using Newtonsoft.Json;

namespace QuestionnaireServices.Models;

/// <summary>
///     Модель ответа на вопрос
/// </summary>
public class AnswerModel
{
    /// <summary>
    ///     Id
    /// </summary>
    [JsonProperty("id")]
    public long Id { get; set; }
    
    /// <summary>
    ///     Ответ
    /// </summary>
    [JsonProperty("response")]
    public string Response { get; set; }
}