using FluentValidation;

namespace FIFA.Application.Footballers.Commands.UpdateFootballer
{
    public class UpdateFootballerCommandValidator : AbstractValidator<UpdateFootballerCommand>
    {
        public UpdateFootballerCommandValidator()
        {
            RuleFor(createFootballerCommand => createFootballerCommand.FirstName).NotEmpty().MaximumLength(150);
            RuleFor(createFootballerCommand => createFootballerCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
