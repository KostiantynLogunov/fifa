using FIFA.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FIFA.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration) 
        {
            var connectionString = configuration["DbConnection"];

            services.AddDbContext<FootballersDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });

            services.AddScoped<IFootballersDbContext>(provider => provider.GetService<FootballersDbContext>());

            return services;
        }
    }
}
