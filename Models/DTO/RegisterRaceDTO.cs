using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace iRacing_League_Scoring.Models.DTO 
{
    public class RegisterRaceDTO
    {
        public int SeasonId { get; set; }
        public int RaceNumber { get; set; }
        public int RaceType { get; set; }
        public IFormFile File {get;set;}

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}