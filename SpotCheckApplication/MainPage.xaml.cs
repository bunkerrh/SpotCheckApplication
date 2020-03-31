
using SpotCheckApplication.Classes;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace SpotCheckApplication
{
    public partial class MainPage : ContentPage
    {
        static double lat;
        static double lng;
        bool timerOn = false;
      
        public MainPage()
        {
          
        }
        protected override void OnDisappearing()
        {
            timerOn = false;
            base.OnDisappearing();
        }
    }

}
