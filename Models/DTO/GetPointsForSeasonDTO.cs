using iRacing_League_Scoring.Enums;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace iRacing_League_Scoring.Models.DTO 
{
    public class GetPointsForSeasonDTO
    {
        public long SeasonId { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}