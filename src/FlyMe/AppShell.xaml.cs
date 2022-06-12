using FlyMe.Views;

namespace FlyMe
{
    public partial class AppShell
    {
        public AppShell()
        {
            InitializeComponent();


            InitRoutes();
        }

        private void InitRoutes()
        {
            Routing.RegisterRoute("results", typeof(FlightResultsPage));
        }

        private async void MenuItem_Clicked(object sender, System.EventArgs e)
        {
            await SecureStorage.SetAsync(App.REMEMBER_ME, false.ToString());
            await Shell.Current.GoToAsync("///login");
            Shell.SetFlyoutBehavior(Shell.Current, FlyoutBehavior.Disabled);
            Shell.Current.FlyoutIsPresented = false;
        }
    }
}
