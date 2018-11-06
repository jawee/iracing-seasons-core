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

namespace iRacing_League_Scoring.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterRacesController : IRControllerBase
    {
        private readonly IRegisterRaceManager _manager;
        public RegisterRacesController(IServiceProvider service) : base(service)
        {
            _manager = Service.GetService<IRegisterRaceManager>();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello");
        }

        [HttpPost]
        public ActionResult Post([FromForm] RegisterRaceDTO input)
        {
            _manager.RegisterRace(input);
            return Ok("Done");
        }
    }
}