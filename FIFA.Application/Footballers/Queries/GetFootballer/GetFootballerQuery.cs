using MediatR;

namespace FIFA.Application.Footballers.Queries.GetFootballer
{
    public class GetFootballerQuery: IRequest<FootballerVm>
    {
        public Guid Id { get; set; }
    }
}
