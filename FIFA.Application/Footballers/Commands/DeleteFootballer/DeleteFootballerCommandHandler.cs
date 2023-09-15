using FIFA.Application.Common.Excaptions;
using FIFA.Application.Interfaces;
using FIFA.Domain;
using MediatR;

namespace FIFA.Application.Footballers.Commands.DeleteFootballer
{
    public class DeleteFootballerCommandHandler : IRequestHandler<DeleteFootballerCommand>
    {
        private readonly IFootballersDbContext dbContext;

        public DeleteFootballerCommandHandler(IFootballersDbContext dbContext) =>
            this.dbContext = dbContext;

        public async Task Handle(DeleteFootballerCommand request, CancellationToken cancellationToken)
        {
            var player = await dbContext.Footballers.FindAsync(new object[] { request.Id }, cancellationToken);

            if (player != null || player.Id != request.Id) {
                throw new NotFoundException(nameof(Footballer), request.Id);
            }

            dbContext.Footballers.Remove(player);

            await dbContext.SaveChangesAsync(cancellationToken);

        }
    }
}
