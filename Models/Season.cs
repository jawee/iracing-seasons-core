using System;
using System.Collections.Generic;

namespace iRacing_League_Scoring.Models {
    public class Season
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<Race> Races { get; set; }
    }
}