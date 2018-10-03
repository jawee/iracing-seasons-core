using CsvHelper.Configuration;
using Newtonsoft.Json;

namespace iRacing_League_Scoring.Models.DTO
{
    public class RaceRowCsvModelDTO
    {
        public int FinPos { get; set; }
        public int CarID { get; set; }
        public string Car { get; set; }
        public int CarClassID { get; set; }
        public string CarClass { get; set; }
        public int TeamID { get; set; }
        public int CustID { get; set; }
        public string Name { get; set; }
        public int StartPos { get; set; }
        public int CarNumber { get; set; }
        public string OutID { get; set; }
        public string Out { get; set; }
        public string Interval { get; set; }
        public int LapsLed { get; set; }
        public string QualifyTime { get; set; }
        public string AverageLapTime { get; set; }
        public string FastestLapTime { get; set; }
        public int? FastLap { get; set; }
        public string LapsComp { get; set; }
        public int Inc { get; set; }
        public int Pts { get; set; }
        public int ClubPts { get; set; }
        public int Div { get; set; }
        public int ClubID { get; set; }
        public string Club { get; set; }
        public int OldiRating { get; set; }
        public int NewiRating { get; set; }
        public int OldLicenseLevel { get; set; }
        public int OldLicenseSub_Level { get; set; }
        public int NewLicenseLevel { get; set; }
        public int NewLicenseSub_Level { get; set; }
        public string SeriesName { get; set; }
        public int MaxFuelFill { get; set; }
        public int WeightPenaltyKG { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class RaceRowCsvModelDTOClassMap : ClassMap<RaceRowCsvModelDTO>
    {
        public RaceRowCsvModelDTOClassMap()
        {
            Map(m => m.FinPos).Name("Fin Pos");
            Map(m => m.CarID).Name("Car ID");
            Map(m => m.Car).Name("Car");
            Map(m => m.CarClassID).Name("Car Class ID");
            Map(m => m.CarClass).Name("Car Class");
            Map(m => m.TeamID).Name("Team ID");
            Map(m => m.CustID).Name("Cust ID");
            Map(m => m.Name).Name("Name");
            Map(m => m.StartPos).Name("Start Pos");
            Map(m => m.CarNumber).Name("Car #");
            Map(m => m.OutID).Name("Out ID");
            Map(m => m.Out).Name("Out");
            Map(m => m.Interval).Name("Interval");
            Map(m => m.LapsLed).Name("Laps Led");
            Map(m => m.QualifyTime).Name("Qualify Time");
            Map(m => m.AverageLapTime).Name("Average Lap Time");
            Map(m => m.FastestLapTime).Name("Fastest Lap Time");
            Map(m => m.FastLap).Name("Fast Lap#");
            Map(m => m.LapsComp).Name("Laps Comp");
            Map(m => m.Inc).Name("Inc");
            Map(m => m.Pts).Name("Pts", "League Points");
            Map(m => m.ClubPts).Name("Club Pts");
            Map(m => m.Div).Name("Div");
            Map(m => m.ClubID).Name("Club ID");
            Map(m => m.Club).Name("Club");
            Map(m => m.OldiRating).Name("Old iRating");
            Map(m => m.NewiRating).Name("New iRating");
            Map(m => m.OldLicenseLevel).Name("Old License Level");
            Map(m => m.OldLicenseSub_Level).Name("Old License Sub-Level");
            Map(m => m.NewLicenseLevel).Name("New License Level");
            Map(m => m.NewLicenseSub_Level).Name("New License Sub-Level");
            Map(m => m.SeriesName).Name("Series Name");
            Map(m => m.MaxFuelFill).Name("Max Fuel Fill%");
            Map(m => m.WeightPenaltyKG).Name("Weight Penalty (KG)");
        }
    }
}