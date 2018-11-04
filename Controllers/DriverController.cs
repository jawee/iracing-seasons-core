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
    public class DriverController : IRControllerBase
    {
        private readonly IDriverManager _manager;
        public DriverController(IServiceProvider service) : base(service)
        {
            _manager = Service.GetService<IDriverManager>();
        }

        [HttpGet]
        public ActionResult<List<Driver>> GetAllRaces()
        {
            var result = _manager.GetDrivers();
            return result;
        }

        [HttpGet("{id}", Name = "GetDriver")]
        public ActionResult<Driver> GetById(long id)
        {
            var result = _manager.GetDriver(id);
            return result;
        }
    }
}