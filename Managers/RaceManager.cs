using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iRacing_League_Scoring.Managers.Interfaces;
using iRacing_League_Scoring.Models;
using Microsoft.EntityFrameworkCore;

namespace iRacing_League_Scoring.Managers
{
    public class RaceManager : ManagerBase, IRaceManager
    {
        public RaceManager(IServiceProvider service) : base(service)
        {
        }

        public Race CreateRace(Race race)
        {
            Context.Races.Add(race);
            Context.SaveChanges();
            return race;
        }

        public bool DeleteRace(long id)
        {
            var race = Context.Races.Find(id);
            if (race == null)
            {
                return false;
            }

            Context.Races.Remove(race);
            Context.SaveChanges();
            return true;
        }

        public Race GetRace(long id)
        {
            var race = Context.Races.Find(id);
            if(race == null) 
            {
                return null;
            }
            Context.Entry(race).Collection(r => r.RaceRows).Load();
            return race;
        }

        public List<Race> GetRaces()
        {
            return Context.Races.Include(r => r.RaceRows).ToList();
        }

        public bool UpdateRace(long id, Race item)
        {
            var race = Context.Races.Find(id);
            if(race == null)
            {
                return false;
            }
            race.SeasonId = item.SeasonId;
            race.RaceNumber = item.RaceNumber;
            race.Track = item.Track;
            
            Context.Races.Update(race);
            Context.SaveChanges();
            return true;
        }
    }
}
