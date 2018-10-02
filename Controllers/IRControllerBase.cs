using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iRacing_League_Scoring.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace iRacing_League_Scoring.Controllers
{
    public class IRControllerBase : ControllerBase
    {
        public IServiceProvider Service { get; set; }
        public IRacingLeagueScoringContext Context;
        public IRControllerBase(IServiceProvider service)
        {
            Service = service;
            Context = Service.GetService<IRacingLeagueScoringContext>();
        }
    }
}
