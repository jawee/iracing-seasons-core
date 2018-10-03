using System;
using Microsoft.EntityFrameworkCore;
using iRacing_League_Scoring.Models;

namespace iRacing_League_Scoring.Contexts 
{
    public class IRacingLeagueScoringContext : DbContext
    {
        public IRacingLeagueScoringContext(DbContextOptions<IRacingLeagueScoringContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Season>().HasMany(s => s.Races).WithOne(s => s.Season);
            modelBuilder.Entity<Race>().HasOne(r => r.Season);
        }

        public DbSet<Season> Seasons { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<RaceRow> RaceRows { get; set; }
        
    }
}