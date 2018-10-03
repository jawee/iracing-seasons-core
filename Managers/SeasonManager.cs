using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iRacing_League_Scoring.Managers.Interfaces;
using iRacing_League_Scoring.Models;
using Microsoft.EntityFrameworkCore;

namespace iRacing_League_Scoring.Managers
{
    public class SeasonManager : ManagerBase, ISeasonManager
    {
        public SeasonManager(IServiceProvider service) : base(service)
        {
        }

        public Season CreateSeason(Season season)
        {
            Context.Seasons.Add(season);
            Context.SaveChanges();
            return season;
        }

        public bool DeleteSeason(long id)
        {
            var season = Context.Seasons.Find(id);
            if (season == null)
            {
                return false;
            }

            Context.Seasons.Remove(season);
            Context.SaveChanges();
            return true;
        }

        public Season GetSeason(long id)
        {
            var season = Context.Seasons.Find(id);
            if(season == null) {
                return null;
            }
            Context.Entry(season).Collection(r => r.Races).Load();
            return season;
        }

        public List<Season> GetSeasons()
        {
            return Context.Seasons.Include(s => s.Races).ToList();
        }

        public bool UpdateSeason(long id, Season item)
        {
            var season = Context.Seasons.Find(id);
            if(season == null)
            {
                return false;
            }
            season.Name = item.Name;
            season.StartDate = item.StartDate;
            season.EndDate = item.EndDate;
            Context.Seasons.Update(season);
            Context.SaveChanges();
            return true;
        }
    }
}
