using FluentValidation;
using QuestionnaireServices.Models.Requests;

namespace QuestionnarieApplication.Validation;

/// <summary>
///     Валидатор для <see cref="UpplyResultRequest"/>
/// </summary>
public class UpplyResultRequestValidator : AbstractValidator<UpplyResultRequest>
{
    /// .ctor
    public UpplyResultRequestValidator()
    {
        RuleFor(_ => _.SurveyId)
            .NotNull()
            .GreaterThan(0)
            .WithMessage("Incorrect survey id");
    
        RuleFor(_ => _.QuestionId)
            .NotEmpty()
            .NotNull()
            .WithMessage("Incorrect question id");
    
        RuleFor(_ => _.InterviewId)
            .NotEmpty();
    }
}