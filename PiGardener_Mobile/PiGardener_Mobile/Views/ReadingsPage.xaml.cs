using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PiGardener_Mobile.Models;
using Newtonsoft.Json.Linq;
using System.IO;
using Android.Content.Res;

namespace PiGardener_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReadingsPage : ContentPage
    {
        bool is_device_selected = false;
        List<Models.PiDevice> all_devices = new List<Models.PiDevice>();
        AssetManager assets = Android.App.Application.Context.Assets;
        public ReadingsPage()
        {
            InitializeComponent();
            is_device_selected = false;
            GetAllDevices();
            PopulateDevicePicker();
        }

        private void GetAllDevices()
        {
            using (var stream_reader = new StreamReader(assets.Open("devices_manifest.json")))
            {
                var json_data = stream_reader.ReadToEnd();
                JArray json_array = JArray.Parse(json_data);

                foreach (JObject device in json_array.Children())
                {
                    Models.PiDevice rPi_server = new Models.PiDevice();
                    rPi_server.Name = device.Property("name").Value.ToString();
                    rPi_server.IP_Addr = device.Property("ip").Value.ToString();
                    rPi_server.Location = device.Property("location").Value.ToString();
                    //Console.WriteLine(rPi_server.Name + "; " + rPi_server.IP_Addr + "; " + rPi_server.Location);
                    all_devices.Add(rPi_server);
                }
            }
        }

        private void PopulateDevicePicker()
        {
            foreach (PiDevice device in all_devices)
            {
                DevicePicker.Items.Add(device.Name);
            }
        }

        private void DevicePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            StartPolling();
        }

        private async void StartPolling()
        {
            is_device_selected = true;

            await PollServerForReadings();
        }

        private async Task PollServerForReadings()
        {
            while (is_device_selected)
            {
                var client = new HttpClient();
                var humidity = await client.GetStringAsync(@"http://10.137.2.122/PiGardener/?reading=humidity");
                var temperature = await client.GetStringAsync(@"http://10.137.2.122/PiGardener/?reading=temperature");

                TemperatureLabel.Text = "Temperature: " + temperature;
                HumidityLabel.Text = "Humidity: " + humidity;

                await Task.Delay(TimeSpan.FromSeconds(5));
            }
        }
    }
}