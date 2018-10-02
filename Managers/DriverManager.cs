using iRacing_League_Scoring.Contexts;
using iRacing_League_Scoring.Managers.Interfaces;

namespace iRacing_League_Scoring.Managers 
{
    public class DriverManager : ManagerBase, IDriverManager
    {
        public DriverManager(IRacingLeagueScoringContext context) : base(context)
        {
        }
    }
}