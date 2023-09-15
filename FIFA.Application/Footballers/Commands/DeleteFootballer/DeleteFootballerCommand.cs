using MediatR;

namespace FIFA.Application.Footballers.Commands.DeleteFootballer
{
    public class DeleteFootballerCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
