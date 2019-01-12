using iRacing_League_Scoring.Enums;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace iRacing_League_Scoring.Models.DTO 
{
    public class RaceResultDTO
    {
        public long RaceNumber { get; set; }
        public int Points { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}