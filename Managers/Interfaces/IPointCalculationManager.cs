using System.Collections.Generic;
using iRacing_League_Scoring.Models;
using iRacing_League_Scoring.Models.DTO;

namespace iRacing_League_Scoring.Managers.Interfaces
{
    public interface IPointCalculationManager : IManagerBase
    {
        int CalculatePointsForDriverInSeason(long driverId, long seasonId);
        List<PointScoringDTO> GetPointsForSeason(long seasonId);
    }
}