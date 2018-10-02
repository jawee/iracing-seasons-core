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

        public DbSet<Season> Seasons { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<RaceRow> RaceRows { get; set; }
        
    }
}