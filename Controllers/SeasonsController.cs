using Microsoft.AspNetCore.Mvc;
using iRacing_League_Scoring.Contexts;
using iRacing_League_Scoring.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using iRacing_League_Scoring.Managers;
using iRacing_League_Scoring.Managers.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace iRacing_League_Scoring.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeasonsController : IRControllerBase
    {

        private readonly ISeasonManager _manager;
        
        public SeasonsController(IServiceProvider service) : base(service)
        {
            _manager = Service.GetService<ISeasonManager>();
        }

        [HttpGet]
        public ActionResult<List<Season>> GetAll()
        {
            var results = _manager.GetSeasons();
            return results;
        }

        [HttpGet("{id}", Name = "GetSeason")]
        public ActionResult<Season> GetById(long id)
        {
            var result = _manager.GetSeason(id);
            return result;
        }

        [HttpPost]
        public IActionResult Create(Season item)
        {
            _manager.CreateSeason(item);

            return CreatedAtRoute("GetSeason", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, Season item)
        {
            var result = _manager.UpdateSeason(id, item);
            if(result) 
            {
                return NoContent();    
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var result = _manager.DeleteSeason(id);
            if(result)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}