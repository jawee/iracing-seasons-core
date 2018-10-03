using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iRacing_League_Scoring.Managers.Interfaces;
using iRacing_League_Scoring.Models;

namespace iRacing_League_Scoring.Managers
{
    public class RaceRowManager : ManagerBase, IRaceRowManager
    {
        public RaceRowManager(IServiceProvider service) : base(service)
        {
        }

        public RaceRow CreateRaceRow(RaceRow raceRow)
        {
            Context.RaceRows.Add(raceRow);
            Context.SaveChanges();
            return raceRow;
        }

        public bool DeleteRaceRow(long id)
        {
            var raceRow = Context.RaceRows.Find(id);
            if (raceRow == null)
            {
                return false;
            }

            Context.RaceRows.Remove(raceRow);
            Context.SaveChanges();
            return true;
        }

        public RaceRow GetRaceRow(long id)
        {
            var raceRow = Context.RaceRows.Find(id);
            if(raceRow == null) 
            {
                return null;
            }
            return raceRow;
        }

        public List<RaceRow> GetRaceRows()
        {
            return Context.RaceRows.ToList();
        }

        public bool UpdateRaceRow(long id, RaceRow item)
        {
            var raceRow = Context.RaceRows.Find(id);
            if(raceRow == null)
            {
                return false;
            }
            
            raceRow.InfractionPoints = item.InfractionPoints;
            raceRow.PenaltyPoints = item.PenaltyPoints;
            raceRow.Points = item.Points;
            Context.RaceRows.Update(raceRow);
            Context.SaveChanges();
            return true;
        }
    }
}
