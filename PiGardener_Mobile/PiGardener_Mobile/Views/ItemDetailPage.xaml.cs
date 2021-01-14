using PiGardener_Mobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace PiGardener_Mobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}