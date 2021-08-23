/***
 *
 * CURRENTLY NOT IMPLEMENTED - VALIDATION ABSTRACTION NOT SET UP.
 *
 */

using FluentValidation;

namespace Qna.Application.Questions.Commands.CreateQuestion
{
    public class CreateQuestionCommandValidator : AbstractValidator<CreateQuestionCommand>
    {
        public CreateQuestionCommandValidator()
        {
            RuleFor(d => d.Title).MaximumLength(64).NotEmpty();
            RuleFor(d => d.Text).NotEmpty();
        }
    }
}