using System;
using System.Collections.Generic;
using System.Linq;
using iRacing_League_Scoring.Contexts;
using iRacing_League_Scoring.Managers.Interfaces;
using iRacing_League_Scoring.Models;
using iRacing_League_Scoring.Models.DTO;

namespace iRacing_League_Scoring.Managers 
{
    public class DriverManager : ManagerBase, IDriverManager
    {
        public DriverManager(IServiceProvider service) : base(service)
        {
        }

        public Driver CreateDriver(Driver driver)
        {
            Context.Drivers.Add(driver);
            Context.SaveChanges();
            return driver;
        }

        public bool DeleteDriver(long id)
        {
            var driver = Context.Drivers.Find(id);
            if(driver == null)
            {
                return false;
            }

            Context.Drivers.Remove(driver);
            Context.SaveChanges();
            return true;
        }

        public Driver GetDriver(long id)
        {
            var driver = Context.Drivers.Find(id);
            if(driver == null)
            {
                return null;
            }
            return driver;
        }

        public Driver GetDriverByCustomerId(int customerId)
        {
            var driver = Context.Drivers.SingleOrDefault(d => d.CustomerId == customerId);
            if(driver == null)
            {
                return null;
            }
            return driver;
        }

        public long GetDriverIdByCustomerIdOrCreate(RaceRowCsvModelDTO record)
        {
            var driver = GetDriverByCustomerId(record.CustID);
            if(driver == null)
            {
                driver = CreateDriver(new Driver() { CustomerId = record.CustID, Name = record.Name, Number = record.CarNumber});
            }
            return driver.Id;
        }

        public List<Driver> GetDrivers()
        {
            return Context.Drivers.ToList();
        }

        public bool UpdateDriver(long id, Driver item)
        {
            var driver = Context.Drivers.Find(id);
            if(driver == null)
            {
                return false;
            }
            driver.Name = item.Name;
            driver.Number = item.Number;
            Context.Drivers.Update(driver);
            Context.SaveChanges();
            return true;
        }
    }
}