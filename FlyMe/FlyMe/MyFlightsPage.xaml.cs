using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FlyMe
{
    public partial class MyFlightsPage : ContentPage
    {
        public MyFlightsPage()
        {
            InitializeComponent();
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Shell.Current.GoToAsync("//book?from=STL");//?from=STL
        }
    }
}
