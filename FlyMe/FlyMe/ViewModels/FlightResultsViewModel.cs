using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlyMe.ViewModels
{
    public class FlightResultsViewModel : BaseViewModel
    {
        public Command LoadMoreFlightsCommand { get; set; }
        public Command GoToDetailsCommand { get; set; }
        public FlightResultsViewModel()
        {
            LoadMoreFlightsCommand = new Command(LoadMore);
            GoToDetailsCommand = new Command<Flight>(GoToDetails);

            InitData();
        }

        private void GoToDetails(Flight obj)
        {
            Shell.Current.DisplayAlert("Maybe Next Demo", $"So, you wanna go from {obj.From} to {obj.To}, eh?", "G'bye");
        }

        int batchSize = 10;
        int currentFlightIndex = 0;

        async void LoadMore()
        {
            IsBusy = true;

            await Task.Delay(3000);

            FlightsToDisplay.AddRange(
                Flights.Skip(batchSize * currentFlightIndex).Take(batchSize)
            );
            currentFlightIndex += batchSize;

            IsBusy = false;
        }

        public ObservableRangeCollection<Flight> FlightsToDisplay
        {
            get => flightsToDisplay; 
            set
            {
                SetProperty(ref flightsToDisplay, value);
            }
        }

        public List<Flight> Flights { get; set; }

        public List<Flight> FlightsEmpty { get; set; } = new List<Flight>();

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
