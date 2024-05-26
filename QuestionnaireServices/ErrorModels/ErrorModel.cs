using System.Net;
using Newtonsoft.Json;

namespace QuestionnaireServices.ErrorModels;

/// <summary>
///     Модель ошибки
/// </summary>
public class ErrorModel
{
    /// <summary>
    ///     Сообщение
    /// </summary>
    [JsonProperty("message")]
    public string Message { get; set; }
    
    /// <summary>
    ///     Статусный код
    /// </summary>
    [JsonProperty("code")]
    public HttpStatusCode Code { get; set; }
}