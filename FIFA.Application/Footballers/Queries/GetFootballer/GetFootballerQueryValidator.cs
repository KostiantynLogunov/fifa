using FIFA.Application.Footballers.Commands.DeleteFootballer;
using FluentValidation;

namespace FIFA.Application.Footballers.Queries.GetFootballer
{
    public class GetFootballerQueryValidator : AbstractValidator<GetFootballerQuery>
    {
        public GetFootballerQueryValidator()
        {
            RuleFor(getFootballerQuery => getFootballerQuery.Id).NotEqual(Guid.Empty);
        }
    }
}
