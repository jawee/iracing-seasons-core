using Microsoft.AspNetCore.Mvc;
using iRacing_League_Scoring.Contexts;
using iRacing_League_Scoring.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace iRacing_League_Scoring.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeasonsController : ControllerBase
    {
        private readonly IRacingLeagueScoringContext _context;

        public SeasonsController(IRacingLeagueScoringContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Season>> GetAll()
        {
            return _context.Seasons.ToList();
        }

        [HttpGet("{id}", Name = "GetSeason")]
        public ActionResult<Season> GetById(long id)
        {
            var item = _context.Seasons.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create(Season item)
        {
            _context.Seasons.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetSeason", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, Season item)
        {
            var season = _context.Seasons.Find(id);
            if (season == null)
            {
                return NotFound();
            }
            season.Name = item.Name;
            season.StartDate = item.StartDate;
            season.EndDate = item.EndDate;
            
            _context.Seasons.Update(season);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var season = _context.Seasons.Find(id);
            if (season == null)
            {
                return NotFound();
            }

            _context.Seasons.Remove(season);
            _context.SaveChanges();
            return NoContent();
        }
    }
}