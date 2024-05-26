using System.Net;

namespace QuestionnaireServices.ErrorModels;

/// <summary>
///     Модель ошибки
/// </summary>
public class ErrorException : Exception
{
    /// <summary>
    ///     Код ошибки
    /// </summary>
    public HttpStatusCode Code { get;}

    /// .ctor
    public ErrorException(HttpStatusCode code, string message) : base(message)
    {
        Code = code;
    }
}