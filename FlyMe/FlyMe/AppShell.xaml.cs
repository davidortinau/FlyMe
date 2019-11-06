using System;
using System.Collections.Generic;

using Xamarin.Forms;

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
    }
}
