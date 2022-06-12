using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlyMe.ViewModels
{
public class TodayViewModel : ObservableObject
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
