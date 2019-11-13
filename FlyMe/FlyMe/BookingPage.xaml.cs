using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlyMe
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
