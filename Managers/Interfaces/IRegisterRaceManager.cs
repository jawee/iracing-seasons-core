using System.Collections.Generic;
using iRacing_League_Scoring.Models;
using iRacing_League_Scoring.Models.DTO;

namespace iRacing_League_Scoring.Managers.Interfaces
{
    public interface IRegisterRaceManager : IManagerBase
    {
        void RegisterRace(RegisterRaceDTO input);
    }
}