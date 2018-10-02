using iRacing_League_Scoring.Contexts;
using iRacing_League_Scoring.Managers.Interfaces;

namespace iRacing_League_Scoring.Managers 
{
    public class ManagerBase : IManagerBase
    {
        private IRacingLeagueScoringContext _context;
        public ManagerBase(IRacingLeagueScoringContext context)
        {
            _context = context;
        }
    }
}