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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PointScoringsController : IRControllerBase
    {
        private readonly IPointCalculationManager _manager;

        public PointScoringsController(IServiceProvider service) : base(service)
        {
            _manager = Service.GetService<IPointCalculationManager>();
        }

        [HttpPost]
        [ActionName("GetPointsForDriverAndSeason")]
        public ActionResult Post([FromForm] GetPointsForDriverAndSeasonDTO input)
        {
            var points = _manager.CalculatePointsForDriverInSeason(input.DriverId, input.SeasonId);
            return Ok(points);
        }

        [HttpPost]
        [ActionName("GetPointsForSeason")]
        public ActionResult<List<PointScoringDTO>> PostSeason([FromForm] GetPointsForSeasonDTO input)
        {
            var result = _manager.GetPointsForSeason(input.SeasonId);
            return result;
        }
    }
}