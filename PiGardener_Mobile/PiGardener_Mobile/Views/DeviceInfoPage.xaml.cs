using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PiGardener_Mobile.Models;
using System.IO;
using Android.Content.Res;

namespace PiGardener_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeviceInfoPage : ContentPage
    {
        List<PiDevice> all_devices = new List<Models.PiDevice>();
        AssetManager assets = Android.App.Application.Context.Assets;
        int total_devices = 0;
        public DeviceInfoPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            DeviceStack.Children.Clear();
            all_devices.Clear();
            //PopulateDeviceList();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("NewDevicePage");
        }

        private void GetAllDevices()
        {
                string json_data = new StreamReader(assets.Open("devices_manifest.json")).ReadToEnd();
                var json_obj = JObject.Parse(json_data);
                var json_array = json_obj.GetValue("Devices") as JArray;

                foreach (JObject device in json_array.Children())
                {
                    PiDevice rPi_server = new PiDevice();
                    rPi_server.ID = Int32.Parse(device.Property("id").Value.ToString());
                    rPi_server.Name = device.Property("name").Value.ToString();
                    rPi_server.IP_Addr = device.Property("ip").Value.ToString();
                    rPi_server.Location = device.Property("location").Value.ToString();
                    //Console.WriteLine(rPi_server.Name + "; " + rPi_server.IP_Addr + "; " + rPi_server.Location);
                    all_devices.Add(rPi_server);
                }
        }

        private void PopulateDeviceList()
        {
            GetAllDevices();
         
            StackLayout main_layout = DeviceStack;
            total_devices = 0;
            foreach (PiDevice device in all_devices)
            {
                StackLayout device_entry = new StackLayout()
                {
                    ClassId = "Device_" + total_devices
                };

                Label device_name = new Label()
                {
                    Text = "#" + device.ID.ToString() + " - " + device.Name,
                    FontSize = 26
                };

                device_entry.Children.Add(device_name);

                main_layout.Children.Add(device_entry);
            }
        }
    }
}