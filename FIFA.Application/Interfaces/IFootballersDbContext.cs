using FIFA.Domain;
using Microsoft.EntityFrameworkCore;

namespace FIFA.Application.Interfaces
{
    public interface IFootballersDbContext
    {
        DbSet<Footballer> Footballer { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
