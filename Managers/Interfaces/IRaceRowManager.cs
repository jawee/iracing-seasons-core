using System.Collections.Generic;
using iRacing_League_Scoring.Models;

namespace iRacing_League_Scoring.Managers.Interfaces
{
    public interface IRaceRowManager : IManagerBase
    {
        RaceRow CreateRaceRow(RaceRow driver);
        List<RaceRow> GetRaceRows();
        RaceRow GetRaceRow(long id);
        bool DeleteRaceRow(long id);
        bool UpdateRaceRow(long id, RaceRow item);

        List<RaceRow> GetRaceRowsForDriverInSeason(long driverId, long seasonId);
        
        List<RaceRow> GetRaceRowsForRaceId(long raceId);
    }
}