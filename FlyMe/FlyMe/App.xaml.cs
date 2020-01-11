using FlyMe.common;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlyMe
{
    public partial class App : Application
    {
        public static string REMEMBER_ME = "remember_me";

        public App()
        {
            StyleSheetRegistrar.RegisterStyle("-xf-horizontal-options", typeof(VisualElement), nameof(View.HorizontalOptionsProperty));
            StyleSheetRegistrar.RegisterStyle("-xf-shell-navbarhasshadow", typeof(Shell), nameof(Shell.NavBarHasShadowProperty));

            InitializeComponent();

            Device.SetFlags(new[] { "CarouselView_Experimental", "IndicatorView_Experimental" } );

            MainPage = new AppTabs();
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
