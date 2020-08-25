using FlyMe.ViewModels.Messages;
using FlyMe.Views;
using System.Threading.Tasks;
using TinyMessenger;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FlyMe
{
    public partial class AppShell
    {
        TinyMessengerHub _hub;

        public AppShell()
        {
            InitializeComponent();

            _hub = DependencyService.Resolve<TinyMessengerHub>();

            InitRoutes();
        }

        private void InitRoutes()
        {
            Routing.RegisterRoute("results", typeof(FlightResultsPage));
        }

        private async void MenuItem_Clicked(object sender, System.EventArgs e)
        {
            _hub.PublishAsync<LoggedOutMessage>(new LoggedOutMessage());
            await SecureStorage.SetAsync(App.REMEMBER_ME, false.ToString());
            //Shell.SetFlyoutBehavior(Shell.Current, FlyoutBehavior.Disabled);
            Shell.Current.FlyoutIsPresented = false;
            await Task.Delay(100);
            await Shell.Current.GoToAsync("///login");
        }
    }
}
