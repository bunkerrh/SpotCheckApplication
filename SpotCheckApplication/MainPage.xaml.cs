
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
        CustomMap customMap = new CustomMap()
        {
            MapType = MapType.Street,
            WidthRequest = App.ScreenWidth,
            HeightRequest = App.ScreenHeight
        };
        public MainPage()
        {
            InitializeComponent();
            btnCreate.Clicked += BtnCreate_Clicked;
            btnJoin.Clicked += BtnJoin_Clicked;
            MenuPage.prevPage = this.Title;
            MenuPage.pageCount += 1;
        }
        protected override void OnDisappearing()
        {
            timerOn = false;
            base.OnDisappearing();
        }
        protected override void OnAppearing()
        {
            timerOn = true;
            AppPinOnLoad();
            InitTimer();
        }

        public void InitTimer()
        {
            int secondsInterval = 5;
            Device.StartTimer(System.TimeSpan.FromSeconds(secondsInterval), () =>
            {
                Device.BeginInvokeOnMainThread(() => AddPinsToMap());
                return timerOn;
            });
        }
        private async void AddPinsToMap()
        {
            await MapUtils.RetrieveLocation();
            lat = MapUtils.getLat();
            lng = MapUtils.getLng();

            var customPin = new CustomPin
            {
                Type = PinType.Place,
                Position = new Position(lat, lng),
                Label = "My Position!",
                Id = "myPin",
                Url = "homepages.uc.edu/~ringjy"
            };
            //Add pin to map
            customMap.Pins.Clear();
            customMap.Pins.Add(customPin);
        }

        //Adds the first pin to the map and pans to that pins location
        private async void AddPinOnLoad()
        {
            await MapUtils.RetrieveLocation();
            lat = MapUtils.getLat();
            lng = MapUtils.getLng();

            var customPin = new CustomPin
            {
                Type = PinType.Place,
                Position = new Position(lat, lng),
                Label = "My Position!",
                Id = "myPin",
                Url = "homepages.uc.edu/~ringjy"
            };

            //Add pin to map
            customMap.Pins.Clear();
            customMap.Pins.Add(customPin);

            //Center map on user/pin location
            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(lat, lng), Distance.FromMiles(0.1)));

        }
        private void AppPinOnLoad()
        {
            var CustomPin = new CustomPin
            {
                Type = PinType.Place,
                Position = new Position(lat, lng),
                Label = "My Positiion!",
                Id = "userPin"
            };

            customMap.Pins.Clear();
            customMap.Pins.Add(CustomPin);
            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(lat, lng), Distance.FromMiles(0.1)));
        }
    }

}
