using iRacing_League_Scoring.Models;

namespace iRacing_League_Scoring.Managers.Interfaces
{
    public interface ISeasonManager : IManagerBase
    {
        Season CreateSeason(Season season);
    }
}