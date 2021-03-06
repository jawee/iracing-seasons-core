using System.Collections.Generic;
using iRacing_League_Scoring.Enums;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace iRacing_League_Scoring.Models.DTO 
{
    public class PointScoringDTO
    {
        public string DriverName { get; set; }
        public int Points { get; set; }

        public List<RaceResultDTO> RaceResults { get; set;}

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}