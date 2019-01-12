using System;
using iRacing_League_Scoring.Managers.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using iRacing_League_Scoring.Enums;
using iRacing_League_Scoring.Scoring;
using iRacing_League_Scoring.Models.DTO;
using System.Collections.Generic;

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

        private List<RaceResultDTO> getRaceResultsForDriverInSeason(long driverId, long seasonId)
        {
            var list = new List<RaceResultDTO>();
            var raceRows = _raceRowManager.GetRaceRowsForDriverInSeason(driverId, seasonId);
            foreach(var raceRow in raceRows)
            {
                if(PointScoring.NormalScoring.ContainsKey(raceRow.Position))
                {
                    list.Add(new RaceResultDTO {RaceNumber = _raceManager.GetRaceNumberForRaceId(raceRow.RaceId), Points = PointScoring.NormalScoring[raceRow.Position]});    
                }
            }

            return list;
        }

        private PointScoringDTO getPointScoringDTOForDriver(long driverId, long seasonId) {
            var driverManager = Service.GetService<IDriverManager>();
            var dto = new PointScoringDTO();
            dto.DriverName = driverManager.GetDriverNameByDriverId(driverId);

            var points = CalculatePointsForDriverInSeason(driverId, seasonId);
            dto.Points = points;

            dto.RaceResults = getRaceResultsForDriverInSeason(driverId, seasonId);

            return dto;
        }

        public List<PointScoringDTO> GetPointsForSeason(long seasonId)
        {
            var driverManager = Service.GetService<IDriverManager>();
            var list = new List<PointScoringDTO>();
            foreach(var driver in Context.Drivers)
            {
                list.Add(getPointScoringDTOForDriver(driver.Id, seasonId));
            }
            return list;
        }
    }
}