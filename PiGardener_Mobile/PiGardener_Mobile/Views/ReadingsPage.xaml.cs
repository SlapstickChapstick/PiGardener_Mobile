using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PiGardener_Mobile.Models;

namespace PiGardener_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReadingsPage : ContentPage
    {
        bool is_device_selected = false;
        List<Models.Device> all_devices = new List<Models.Device>();
        public ReadingsPage()
        {
            InitializeComponent();
            is_device_selected = false;
        }

        private void GetAllDevices()
        {

        }

        private void PopulateDevicePicker()
        {
            
        }

        private async void DevicePicker_SelectedIndexChanged(object sender, EventArgs e)
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