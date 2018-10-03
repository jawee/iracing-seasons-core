using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using CsvHelper;
using iRacing_League_Scoring.Managers.Interfaces;
using iRacing_League_Scoring.Models;
using iRacing_League_Scoring.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace iRacing_League_Scoring.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaceController : IRControllerBase
    {
        private readonly IRaceManager _manager;
        public RaceController(IServiceProvider service) : base(service)
        {
            _manager = Service.GetService<IRaceManager>();
        }

        [HttpGet]
        public ActionResult<string> GetAllRaces()
        {
            var result = _manager.GetRaces();
            return JsonConvert.SerializeObject(result);
        }
    }
}