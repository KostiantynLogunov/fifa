using FIFA.Domain;
using FIFA.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FIFA.Persistence.EntityTypeConfigurations;

namespace FIFA.Persistence
{
    public class FootballersDbContext: DbContext, IFootballersDbContext
    {
        public FootballersDbContext(DbContextOptions<FootballersDbContext> options)
            :base(options) { }

        public DbSet<Footballer> Footballer { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new FootballerConfiguration());
            base.OnModelCreating(builder);
        }

    }
}
