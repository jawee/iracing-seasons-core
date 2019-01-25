using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using iRacing_League_Scoring.Enums;
using iRacing_League_Scoring.Managers.Interfaces;
using iRacing_League_Scoring.Models;
using iRacing_League_Scoring.Models.DTO;
using Microsoft.Extensions.DependencyInjection;

namespace iRacing_League_Scoring.Managers
{
    public class RegisterRaceManager : ManagerBase, IRegisterRaceManager
    {

        private readonly IDriverManager _driverManager;
        private readonly ISeasonManager _seasonManager;
        private readonly IRaceManager _raceManager;
        private readonly IRaceRowManager _raceRowManager;
        public RegisterRaceManager(IServiceProvider service) : base(service)
        {
            _driverManager = Service.GetService<IDriverManager>();
            _seasonManager = Service.GetService<ISeasonManager>();
            _raceManager = Service.GetService<IRaceManager>();
            _raceRowManager = Service.GetService<IRaceRowManager>();
        }

        public void RegisterRace(RegisterRaceDTO input)
        {
            ReadFile(input);
        }

        private void ReadFile(RegisterRaceDTO input)
        {
            var file = input.File;
            var fileReadStream = file.OpenReadStream();
            var track = "";
            
            using (var reader = new StreamReader(fileReadStream))
            {
                if(input.RaceType == RaceType.Normal) //Regular race
                {

                }
                else if(input.RaceType == RaceType.League) //League race
                {
                    Console.WriteLine(reader.ReadLine());
                    var trackLine = reader.ReadLine();
                    Console.WriteLine(trackLine);
                    var list = trackLine.Split(",");
                    track = list[1];
                    track = track.Substring(1, track.Length-2);
                    Console.WriteLine(reader.ReadLine());
                    Console.WriteLine(reader.ReadLine());
                    Console.WriteLine(reader.ReadLine());
                    Console.WriteLine(reader.ReadLine());
                    Console.WriteLine(reader.ReadLine());
                    Console.WriteLine(reader.ReadLine());
                }
                else if(input.RaceType == RaceType.LeageFeature) //League race feature
                {

                }
                else if(input.RaceType == RaceType.LeagueSprint) //League race sprint
                {
                    
                }
                var race = _raceManager.CreateRace(new Race() {RaceNumber = input.RaceNumber, SeasonId = input.SeasonId, Track = track, RaceType = input.RaceType });
                var csv = new CsvReader(reader);
                csv.Configuration.RegisterClassMap<RaceRowCsvModelDTOClassMap>();
                csv.Configuration.MissingFieldFound = null;
                // csv.Read();
                // csv.Read();
                csv.Read();
                csv.ReadHeader();
                var records = csv.GetRecords<RaceRowCsvModelDTO>();
                foreach (var record in records)
                {
                    var raceRow = new RaceRow();
                    raceRow.DriverId = GetDriverId(record);
                    raceRow.Position = record.FinPos;
                    raceRow.Car = record.Car;
                    raceRow.Incidents = record.Inc;
                    raceRow.StartPosition = record.StartPos;
                    raceRow.Points = record.Pts;
                    raceRow.RaceId = race.Id;
                    _raceRowManager.CreateRaceRow(raceRow);
                }
            }
        }
        private long GetDriverId(RaceRowCsvModelDTO record)
        {
            var id = _driverManager.GetDriverIdByCustomerIdOrCreate(record);
            return id;
        }
    }
}
