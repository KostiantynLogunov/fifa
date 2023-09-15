using FIFA.Application.Common.Excaptions;
using FIFA.Application.Interfaces;
using FIFA.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FIFA.Application.Footballers.Commands.UpdateFootballer
{
    public class UpdateFootballerCommandHandler : IRequestHandler<UpdateFootballerCommand>
    {
        private readonly IFootballersDbContext dbContext;

        public UpdateFootballerCommandHandler(IFootballersDbContext dbContext) =>
            this.dbContext = dbContext;
        public async Task Handle(UpdateFootballerCommand request, CancellationToken cancellationToken)
        {
            var player = await dbContext.Footballers.FirstOrDefaultAsync(player => player.Id == request.Id, cancellationToken);

            if (player == null || player.Id != request.Id)
            {
                throw new NotFoundException(nameof(Footballer) , request.Id);
            }

            player.FirstName = request.FirstName;
            player.LastName = request.LastName; 

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
