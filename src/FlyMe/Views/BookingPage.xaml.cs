using System.ComponentModel;


namespace FlyMe.Views
{
    [QueryProperty(nameof(From), "from")]
    [DesignTimeVisible(false)]
    public partial class BookingPage
    {
        public BookingPage()
        {
            InitializeComponent();
        }

        public string From
        {
            set
            {
                FromLabel.Text = value;
            }
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Shell.Current.GoToAsync("results");
        }
    }
}
