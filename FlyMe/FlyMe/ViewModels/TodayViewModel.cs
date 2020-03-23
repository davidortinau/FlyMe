using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Command = Xamarin.Forms.Command;

namespace FlyMe.ViewModels
{
    public class TodayViewModel : BaseViewModel
    {
        public Command FindLocationsCommand { get; set; }

        public DateTime HomeUntilDate { get; set; } = DateTime.Today;

        public TodayViewModel()
        {
            FindLocationsCommand = new Command(FindLocations);
        }

        private async void FindLocations()
        {
            await Shell.Current.GoToAsync($"results?start={HomeUntilDate.ToString("yyyyMMddHHmmss")}");
        }
    }
}
