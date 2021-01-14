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
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
