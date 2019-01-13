using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iRacing_League_Scoring.Managers.Interfaces;
using iRacing_League_Scoring.Models;
using Microsoft.Extensions.DependencyInjection;

namespace iRacing_League_Scoring.Managers
{
    public class RaceRowManager : ManagerBase, IRaceRowManager
    {
        private ISeasonManager _seasonManager;
        private IRaceManager _raceManager;
        public RaceRowManager(IServiceProvider service) : base(service)
        {
            _seasonManager = Service.GetService<ISeasonManager>();
            _raceManager = Service.GetService<IRaceManager>();
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

        private RaceRow GetRaceRowForDriverInRace(long driverId, long raceId)
        {
            var raceRow = Context.RaceRows.SingleOrDefault(rr => rr.RaceId == raceId && rr.DriverId == driverId);
            return raceRow;
        }

        public List<RaceRow> GetRaceRowsForDriverInSeason(long driverId, long seasonId)
        {
            var raceRows = new List<RaceRow>();

            var season = _seasonManager.GetSeason(seasonId);
            if(season != null) {
                foreach(var race in season.Races)
                {
                    var raceRow = GetRaceRowForDriverInRace(driverId, race.Id);
                    if(raceRow != null) 
                    {
                        raceRows.Add(raceRow);
                    }
                }
            }
            return raceRows;
        }

        public List<RaceRow> GetRaceRowsForRaceId(long raceId)
        {
            var raceRows = Context.RaceRows.Where(rr => rr.RaceId == raceId).ToList();

            return raceRows;
        }
    }
}
