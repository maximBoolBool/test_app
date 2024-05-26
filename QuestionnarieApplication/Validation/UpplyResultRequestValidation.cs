using FluentValidation;
using QuestionnaireServices.Models.Requests;

namespace QuestionnarieApplication.Validation;

/// <summary>
///     Валидатор для <see cref="UpplyResultRequest"/>
/// </summary>
public class UpplyResultRequestValidation : AbstractValidator<UpplyResultRequest>
{
    UpplyResultRequestValidation()
    {
        RuleFor(_ => _.SurveyId)
            .NotEmpty()
            .NotNull()
            .WithMessage("Incorrect survey id");

        RuleFor(_ => _.QuestionId)
            .NotEmpty()
            .NotNull()
            .WithMessage("Incorrect question id");

        RuleFor(_ => _.InterviewId)
            .NotEmpty()
            .NotNull();
    }
}