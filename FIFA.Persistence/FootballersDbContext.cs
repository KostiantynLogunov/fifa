﻿using FIFA.Domain;
using FIFA.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using FIFA.Persistence.EntityTypeConfigurations;

namespace FIFA.Persistence
{
    public class FootballersDbContext: DbContext, IFootballersDbContext
    {
        public DbSet<Footballer> Footballers { get; set; }

        public FootballersDbContext(DbContextOptions<FootballersDbContext> options)
            :base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new FootballerConfiguration());
            base.OnModelCreating(builder);
        }

    }
}
