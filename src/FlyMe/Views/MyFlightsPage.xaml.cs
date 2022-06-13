
using System.Threading.Tasks;


namespace FlyMe.Views
{
    public partial class MyFlightsPage
    {
        public MyFlightsPage()
        {
            InitializeComponent();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // this is the sizing that crashes the view
            // var inAnims = new Animation();
            // inAnims.Add(0, 1, new Animation(v => this.MilesProgressBar.WidthRequest = Math.Max(0,v), 0, 200, Easing.SpringIn));
            // inAnims.Add(0.25, 1, new Animation(v => this.SegmentsProgressBar.WidthRequest = Math.Max(0,v), 0, 100, Easing.SpringIn));

            // inAnims.Commit(this, "grow_bar", 16, 2000);
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Shell.Current.GoToAsync("//book?from=STL");
        }
    }
}
