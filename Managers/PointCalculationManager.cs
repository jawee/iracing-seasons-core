using System;
using iRacing_League_Scoring.Managers.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using iRacing_League_Scoring.Enums;
using iRacing_League_Scoring.Scoring;

namespace iRacing_League_Scoring.Managers
{
    public class PointCalculationManager : ManagerBase, IPointCalculationManager
    {
        private readonly IDriverManager _driverManager;
        private readonly ISeasonManager _seasonManager;
        private readonly IRaceManager _raceManager;
        private readonly IRaceRowManager _raceRowManager;
        
        public PointCalculationManager(IServiceProvider service) : base(service)
        {
            _driverManager = Service.GetService<IDriverManager>();
            _seasonManager = Service.GetService<ISeasonManager>();
            _raceManager = Service.GetService<IRaceManager>();
            _raceRowManager = Service.GetService<IRaceRowManager>();
        }

        public int CalculatePointsForDriverInSeason(long driverId, long seasonId)
        {
            var points = 0;
            var driver = _driverManager.GetDriver(driverId);
            var raceRows = _raceRowManager.GetRaceRowsForDriverInSeason(driverId, seasonId);
            foreach(var raceRow in raceRows)
            {
                var place = raceRow.Position;
                if(PointScoring.NormalScoring.ContainsKey(place)) 
                {
                    points += PointScoring.NormalScoring[place];
                }
            }
            return points;
        }
    }
}