using FluentValidation;

namespace FIFA.Application.Footballers.Commands.CreateFootballer
{
    public class CreateFootballerCommandValidator : AbstractValidator<CreateFootballerCommand>
    {
        public CreateFootballerCommandValidator()
        {
            RuleFor(createFootballerCommand => createFootballerCommand.FirstName).NotEmpty().MaximumLength(150);
        }
    }
}
