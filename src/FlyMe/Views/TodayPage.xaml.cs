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
    }
}