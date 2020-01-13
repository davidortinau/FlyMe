using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlyMe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
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
                MessagingCenter.Instance.Send<LoginPage>(this, App.MSG_LOGGED_IN);  
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if(RememberCheck.IsChecked)
            {
                await SecureStorage.SetAsync(App.REMEMBER_ME, RememberCheck.IsChecked.ToString());
            }

            MessagingCenter.Instance.Send<LoginPage>(this, App.MSG_LOGGED_IN);
        }
    }
}