using PiGardener_Mobile.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PiGardener_Mobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ReadingsPage), typeof(ReadingsPage));
            Routing.RegisterRoute(nameof(DeviceInfoPage), typeof(DeviceInfoPage));
            Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
        }
    }
}
