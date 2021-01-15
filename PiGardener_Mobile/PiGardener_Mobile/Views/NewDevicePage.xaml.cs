using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Content.Res;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PiGardener_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewDevicePage : ContentPage
    {
        AssetManager assets = Android.App.Application.Context.Assets;
        public NewDevicePage()
        {
            InitializeComponent();
        }

        private void AddDevice_Btn_Clicked(object sender, EventArgs e)
        {
            string file_name = "devices_manifest.csv";
            var backingFile = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, file_name);

            CheckIfNoDevices();
            GetLastID();
        }

        private void GetLastID()
        {
            int last_id = 0;
            int current_id = 0;

            string file_name = "devices_manifest.csv";
            var devices_file = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, file_name);


        }

        private void CheckIfNoDevices()
        {
            string file_name = "devices_manifest.csv";
            var devices_file = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, file_name);
            if (File.Exists(devices_file))
            {
                Console.WriteLine("Device Manifest Exists!");
            }
            else
            {
                Console.WriteLine("Device Manifest Does Not Exist!");
            }
        }
    }
}