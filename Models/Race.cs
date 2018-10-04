using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using iRacing_League_Scoring.Enums;
using Newtonsoft.Json;

namespace iRacing_League_Scoring.Models {
    public class Race
    {
        public long Id { get; set; }
        public string Track { get; set; }
        public long SeasonId { get; set; }
        [ForeignKey("SeasonId")]
        public Season Season { get; set; }
        public long RaceNumber { get; set; }
        public RaceType RaceType {get;set;}
        public List<RaceRow> RaceRows { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}