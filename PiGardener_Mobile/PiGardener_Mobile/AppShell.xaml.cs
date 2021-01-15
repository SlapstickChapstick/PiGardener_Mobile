using PiGardener_Mobile.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using PCLStorage;
using System.Threading.Tasks;
using System.IO;

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
            Routing.RegisterRoute(nameof(NewDevicePage), typeof(NewDevicePage));
            CreateFolderForDevices();
        }

        private async void CreateFolderForDevices() {
            string folder_name = "devices_manifest.csv";
            var backingFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), folder_name);

            Console.WriteLine(backingFile);
            using (var writer = File.CreateText(backingFile))
            {
                await writer.WriteLineAsync("");
            }
        }
    }
}
