using System;
using iRacing_League_Scoring.Contexts;
using iRacing_League_Scoring.Managers.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace iRacing_League_Scoring.Managers 
{
    public class ManagerBase : IManagerBase
    {
        protected IServiceProvider Service { get; set; }
        protected IRacingLeagueScoringContext Context { get; set; }
        public ManagerBase(IServiceProvider service)
        {
            Service = service;
            Context = Service.GetService<IRacingLeagueScoringContext>();
        }
    }
}