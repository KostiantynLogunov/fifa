using FIFA.Application.Interfaces;
using FIFA.Domain;
using MediatR;

namespace FIFA.Application.Footballers.Commands.CreateFootballer
{
    public class CreateFootballerCommandHandler : IRequestHandler<CreateFootballerCommand, Guid>
    {
        private readonly IFootballersDbContext dbContext;

        public CreateFootballerCommandHandler(IFootballersDbContext dbContext) =>
            this.dbContext = dbContext;

        public async Task<Guid> Handle(CreateFootballerCommand request, CancellationToken cancellationToken)
        {
            var footbaler = new Footballer
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                CreatedAt = DateTime.Now,
                EditedAt = null
            };

            await dbContext.Footballers.AddAsync(footbaler, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return footbaler.Id;
        }
    }
}
