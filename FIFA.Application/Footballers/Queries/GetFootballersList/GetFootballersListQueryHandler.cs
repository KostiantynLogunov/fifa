using AutoMapper;
using AutoMapper.QueryableExtensions;
using FIFA.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FIFA.Application.Footballers.Queries.GetFootballersList
{
    public class GetFootballersListQueryHandler : IRequestHandler<GetFootballersListQuery, FootballersListVm>
    {
        private readonly IFootballersDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetFootballersListQueryHandler(IFootballersDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<FootballersListVm> Handle(GetFootballersListQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dbContext.Footballers
                .ProjectTo<FootballerDto>(_mapper.ConfigurationProvider) // ProjectTo projects our collection accordingly setuped config.
                .ToListAsync(cancellationToken);

            return new FootballersListVm { Footballes = entities };
        }
    }
}
