using System;
using System.Collections.Generic;

namespace iRacing_League_Scoring.Models {
    public class Race
    {
        public long Id { get; set; }
        public string Track { get; set; }
        public long SeasonId { get; set; }
        public Season Season { get; set; }
        public long RaceNumber { get; set; }
        public List<RaceRow> RaceRows { get; set; }
    }
}