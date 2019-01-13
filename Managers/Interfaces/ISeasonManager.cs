using System.Collections.Generic;
using iRacing_League_Scoring.Models;

namespace iRacing_League_Scoring.Managers.Interfaces
{
    public interface ISeasonManager : IManagerBase
    {
        Season CreateSeason(Season season);
        List<Season> GetSeasons();
        Season GetSeason(long id);
        bool DeleteSeason(long id);
        bool UpdateSeason(long id, Season item);
        List<long> GetDriversInSeasonBySeasonId(long seasonId);
    }
}