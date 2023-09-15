using FluentValidation;

namespace FIFA.Application.Footballers.Queries.GetFootballersList
{
    public class GetFootballersListQueryValidator : AbstractValidator<FootballersListVm>
    {
        public GetFootballersListQueryValidator()
        {
        }
    }
}
