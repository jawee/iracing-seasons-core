using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iRacing_League_Scoring.Managers.Interfaces;
using iRacing_League_Scoring.Models;

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
    }
}
