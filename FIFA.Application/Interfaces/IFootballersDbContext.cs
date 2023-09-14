using FIFA.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FIFA.Application.Interfaces
{
    public interface IFootballersDbContext
    {
        DbSet<Footballer> Footballer { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
