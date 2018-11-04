using System.Collections.Generic;
using iRacing_League_Scoring.Models;

namespace iRacing_League_Scoring.Managers.Interfaces
{
    public interface IRaceManager : IManagerBase
    {
        Race CreateRace(Race race);
        List<Race> GetRaces();
        Race GetRace(long id);
        bool DeleteRace(long id);
        bool UpdateRace(long id, Race item);
    }
}