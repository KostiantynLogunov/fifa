using MediatR;

namespace FIFA.Application.Footballers.Commands.CreateFootballer
{
    public class CreateFootballerCommand: IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
