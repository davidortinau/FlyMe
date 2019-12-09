using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FlyMe.ViewModels
{
    [QueryProperty("From", "from")]
    [QueryProperty("To", "to")]
    public class FlightDetailsViewModel : BaseViewModel
    {
        private string from;
        public string From { get => from; set => SetProperty(ref from, value); }
        public string To { get => to; set => SetProperty(ref to, value); }

        private string to;
    }
}
