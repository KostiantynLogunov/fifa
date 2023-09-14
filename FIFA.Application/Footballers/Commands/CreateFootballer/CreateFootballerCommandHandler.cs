using MediatR;

namespace FIFA.Application.Footballers.Commands.CreateFootballer
{
    public class CreateFootballerCommandHandler : IRequestHandler<CreateFootballerCommand, Guid>
    {
        public Task<Guid> Handle(CreateFootballerCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
