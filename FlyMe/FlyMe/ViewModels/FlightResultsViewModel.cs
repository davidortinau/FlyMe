using System;
using System.Collections.Generic;
using MvvmHelpers;

namespace FlyMe.ViewModels
{
    public class FlightResultsViewModel : BaseViewModel
    {
        public FlightResultsViewModel()
        {
            InitData();
        }

        public List<Flight> Flights { get; set; }

        private void InitData()
        {
            Flights = new List<Flight>();
            for(var i = 1; i <= 1000; i++)
            {
                Flights.Add(new Flight
                {
                    From = "STL",
                    To = "MCO",
                    DepartDateTime = new DateTime(2019, 12, 4, 11, 15, 00),
                    ArrivalDateTime = new DateTime(2019, 12, 4, 16, 15, 00),
                    Price = "$500"
                });
            }
        }
    }

    public class Flight
    {
        public string From { get; set; }
        public string To { get; set; }
        public DateTime DepartDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public string Duration
        {
            get
            {
                var d = ArrivalDateTime - DepartDateTime;
                return d.TotalSeconds.ToString();
            }
        }
        public string Price { get; set; }
        public string DepartTime
        {
            get
            {
                return "3:30PM";
            }
        }
        public string ReturnTime
        {
            get
            {
                return "6:15PM";
            }
        }
    }
}
