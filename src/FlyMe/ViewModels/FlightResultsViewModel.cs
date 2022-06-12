using Microsoft.Toolkit.Mvvm.ComponentModel;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;


namespace FlyMe.ViewModels
{
    [QueryProperty(nameof(FromDateIn), "start")]
    public class FlightResultsViewModel : ObservableObject
    {
        public Command GoToDetailsCommand { get; set; }

        public Command LoadMoreFlightsCommand { get; set; }

        public string FromDateIn
        {
            set
            {
                FromDate = DateTime.ParseExact(value, "yyyyMMddHHmmss",
                              CultureInfo.InvariantCulture,
                              DateTimeStyles.AdjustToUniversal);
            }
            get
            {
                return string.Empty;
            }
        }
        public DateTime FromDate { get; set; }

        public string DisplayDate
        {
            get
            {
                if (FromDate > DateTime.MinValue)
                {
                    return $"Free Starting: {FromDate.ToShortDateString()}";
                }
                else
                {
                    return "Results";
                }

            }
        }
        public FlightResultsViewModel()
        {
            GoToDetailsCommand = new Command<Flight>(GoToDetails);
            LoadMoreFlightsCommand = new Command(LoadMoreAsync);

            InitData();
        }

        private async void LoadMoreAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            await Task.Delay(1000); // Fake and API call delay

            FlightsToDisplay.AddRange(
                Flights.Skip(batchSize * currentFlightIndex).Take(batchSize)
            );
            currentFlightIndex += batchSize;

            IsBusy = false;
        }

        private async void GoToDetails(Flight obj)
        {
            await Shell.Current.DisplayAlert("You Deserve It", $"So, you wanna go from {obj.From} to Hawaii, eh?", "Book It!");
            await Shell.Current.GoToAsync("..");
        }

        public List<Flight> Flights { get; set; }

        public List<Flight> FlightsEmpty { get; set; } = new List<Flight>();
        public ObservableRangeCollection<Flight> FlightsToDisplay { get => flightsToDisplay;
            set => SetProperty(ref flightsToDisplay, value); }
        public bool IsBusy { get; private set; }

        Random random = new Random();

        private void InitData()
        {
            Flights = new List<Flight>();
            for (var i = 1; i <= 1000; i++)
            {
                Flights.Add(new Flight
                {
                    From = cities[random.Next(cities.Length - 1)],
                    To = cities[random.Next(cities.Length - 1)],
                    DepartDateTime = departDates[random.Next(departDates.Length - 1)],
                    ArrivalDateTime = arrivalDates[random.Next(arrivalDates.Length - 1)],
                    Price = prices[random.Next(prices.Length - 1)]
                });
            }

            FlightsToDisplay = new ObservableRangeCollection<Flight>(Flights.Take(batchSize).ToList());
        }

        private string[] cities = new string[]
        {
            "STL","MCO","ORD","SEA","SFO","SJC","JFK","BOS"
        };

        private DateTime[] departDates = new DateTime[]
        {
            new DateTime(2019, 12, 4, 10, 15, 00),
            new DateTime(2019, 12, 4, 12, 00, 00),
            new DateTime(2019, 12, 4, 15, 30, 00),
            new DateTime(2019, 12, 4, 17, 00, 00),
            new DateTime(2019, 12, 4, 18, 15, 00),
            new DateTime(2019, 12, 4, 20, 45, 00)
        };

        private DateTime[] arrivalDates = new DateTime[]
        {
            new DateTime(2019, 12, 15, 10, 15, 00),
            new DateTime(2019, 12, 15, 12, 00, 00),
            new DateTime(2019, 12, 15, 15, 30, 00),
            new DateTime(2019, 12, 15, 17, 00, 00),
            new DateTime(2019, 12, 15, 18, 15, 00),
            new DateTime(2019, 12, 15, 20, 45, 00)
        };

        private string[] prices = new string[]
        {
            "$500", "$1,200", "$350", "$750", "$1,250", "$200"
        };
        private ObservableRangeCollection<Flight> flightsToDisplay;
        private int batchSize = 20;
        private int currentFlightIndex = 0;
    }

    public class Flight
    {
        public string From { get; set; }
        public string To { get; set; }
        public DateTime DepartDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }


        Random randomGen = new Random();
        public string PhotoUrl
        {
            get
            {
                int rInt = randomGen.Next(1, 10);
                return $"beach_{rInt}.jpg";
            }
        }

        public string LocationName
        {
            get
            {
                return "Maui, Hawaii";
            }
        }

        public string Stops
        {
            get
            {
                if(To == "STL")
                {
                    return "2 stops:<br/>MDW<br/>CCT<br/>Direct upgrade available";
                }
                else
                {
                    return "Non-stop";
                }
            }
        }
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
                return DepartDateTime.ToShortTimeString();
            }
        }
        public string ArrivalTime
        {
            get
            {
                return ArrivalDateTime.ToShortTimeString();
            }
        }
    }
}
