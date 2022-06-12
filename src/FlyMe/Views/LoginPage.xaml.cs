using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FlyMe.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            CheckAuth();
        }

        private async void CheckAuth()
        {
            var remember = await SecureStorage.GetAsync(App.REMEMBER_ME);
            if (Convert.ToBoolean(remember))
            {
                await Shell.Current.GoToAsync("///home");
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if(RememberCheck.IsChecked)
            {
                // store in essentials
                SecureStorage.SetAsync(App.REMEMBER_ME, RememberCheck.IsChecked.ToString());
            }

            await Shell.Current.GoToAsync("///home");
            Shell.SetFlyoutBehavior(Shell.Current, FlyoutBehavior.Flyout);
        }

        void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
                    
        }
    }
}