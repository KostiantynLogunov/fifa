using FluentValidation;

namespace FIFA.Application.Footballers.Commands.DeleteFootballer
{
    public class DeleteFootballerCommandValidator : AbstractValidator<DeleteFootballerCommand>
    {
        public DeleteFootballerCommandValidator()
        {
            RuleFor(createFootballerCommand => createFootballerCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
