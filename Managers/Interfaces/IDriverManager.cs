using System.Collections.Generic;
using iRacing_League_Scoring.Models;
using iRacing_League_Scoring.Models.DTO;

namespace iRacing_League_Scoring.Managers.Interfaces
{
    public interface IDriverManager : IManagerBase
    {
        Driver CreateDriver(Driver driver);
        List<Driver> GetDrivers();
        Driver GetDriver(long id);
        bool DeleteDriver(long id);
        bool UpdateDriver(long id, Driver item);
        Driver GetDriverByCustomerId(int customerId);
        
        long GetDriverIdByCustomerIdOrCreate(RaceRowCsvModelDTO record);
    }
}