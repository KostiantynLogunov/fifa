using AutoMapper;
using FIFA.Application.Common.Excaptions;
using FIFA.Application.Interfaces;
using FIFA.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FIFA.Application.Footballers.Queries.GetFootballer
{
    public class GetFootballerQueryHandler : IRequestHandler<GetFootballerQuery, FootballerVm>
    {
        private readonly IFootballersDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetFootballerQueryHandler(IFootballersDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<FootballerVm> Handle(GetFootballerQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Footballers.FirstOrDefaultAsync(player => player.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Footballer), request.Id);
            }

            return _mapper.Map<FootballerVm>(entity);
        }
    }
}
