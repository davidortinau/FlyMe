using FlyMe.common;
using FlyMe.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlyMe
{
    public partial class App : Application
    {
        public static string REMEMBER_ME = "remember_me";
        public static string MSG_LOGGED_IN = "logged_in";
        public static string MSG_BOOK = "book";

        public App()
        {
            StyleSheetRegistrar.RegisterStyle("-xf-horizontal-options", typeof(VisualElement), nameof(View.HorizontalOptionsProperty));
            StyleSheetRegistrar.RegisterStyle("-xf-shell-navbarhasshadow", typeof(Shell), nameof(Shell.NavBarHasShadowProperty));

            InitializeComponent();

            Device.SetFlags(new[] { "CarouselView_Experimental", "IndicatorView_Experimental" } );

            MainPage = new LoginPage();

            MessagingCenter.Subscribe<LoginPage>(this, App.MSG_LOGGED_IN, GoToApp);
            MessagingCenter.Subscribe<Application>(this, App.MSG_BOOK, GoToBooking);
        }

        private void GoToApp(ContentPage sender)
        {
            App.Current.MainPage = new NavigationPage(new AppTabs())
            {
                BarBackgroundColor = (Color)App.Current.Resources["PrimaryColor"],
                BarTextColor = Color.White
            };
        }
        private void GoToBooking(Application sender)
        {
            ((NavigationPage)App.Current.MainPage).PushAsync(new BookingPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

    }
}
