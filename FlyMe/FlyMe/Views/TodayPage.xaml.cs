using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlyMe.Views
{
    public partial class TodayPage : ContentPage
    {
        public TodayPage()
        {
            InitializeComponent();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            // GoTo Destinations
            await Shell.Current.GoToAsync("book?from=STL");
        }

void RadioButton_CheckedChanged(object sender, EventArgs e)
{
    RadioButton rb = sender as RadioButton;
    if(rb.IsChecked)
        Debug.WriteLine($"You chose: {rb.GroupName} : {rb.Text}");
}
    }
}