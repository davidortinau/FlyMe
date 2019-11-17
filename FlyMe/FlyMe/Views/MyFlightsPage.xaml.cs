
using Xamarin.Forms;

namespace FlyMe.Views
{
    public partial class MyFlightsPage
    {
        public MyFlightsPage()
        {
            InitializeComponent();
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Shell.Current.GoToAsync("//book?from=STL");
        }
    }
}
