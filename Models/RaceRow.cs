using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace iRacing_League_Scoring.Models {
    public class RaceRow
    {
        public long Id { get; set; }
        public string Car { get; set; }
        public int Position { get; set; }
        public int StartPosition { get; set; }
        public int Incidents { get; set; }
        public int Points { get; set; }
        public int InfractionPoints { get; set; }
        public int PenaltyPoints { get; set; }

        //relations id
        public long RaceId { get; set; }
        public long DriverId { get; set; }

        //Relations entity
        [ForeignKey("RaceId")]
        public Race Race { get; set; }
        [ForeignKey("DriverId")]
        public Driver Driver { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}