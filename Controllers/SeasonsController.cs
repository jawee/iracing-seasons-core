using Microsoft.AspNetCore.Mvc;
using iRacing_League_Scoring.Contexts;
using iRacing_League_Scoring.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using iRacing_League_Scoring.Managers;
using iRacing_League_Scoring.Managers.Interfaces;
using Microsoft.Extensions.DependencyInjection;

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
            return Context.Seasons.ToList();
        }

        [HttpGet("{id}", Name = "GetSeason")]
        public ActionResult<Season> GetById(long id)
        {
            var item = Context.Seasons.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
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
            var season = Context.Seasons.Find(id);
            if (season == null)
            {
                return NotFound();
            }
            season.Name = item.Name;
            season.StartDate = item.StartDate;
            season.EndDate = item.EndDate;

            Context.Seasons.Update(season);
            Context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var season = Context.Seasons.Find(id);
            if (season == null)
            {
                return NotFound();
            }

            Context.Seasons.Remove(season);
            Context.SaveChanges();
            return NoContent();
        }
    }
}