using System;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace FlyMe.ViewModels
{
    public class BagTrackerViewModel : ObservableObject
    {
        public Command SearchCommand { get; internal set; }

        public BagTrackerViewModel()
        {
            SearchCommand = new Command(OnSearch);
        }

        private void OnSearch()
        {
            App.Current.MainPage.DisplayAlert("Bags Found!", "They are in your closet because you're staying at home!", "Thanks!");
        }
    }
}

