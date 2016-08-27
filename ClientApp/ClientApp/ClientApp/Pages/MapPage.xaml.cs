namespace ClientApp.Pages
{
    using ViewModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xamarin.Forms.Maps;
    using System.Linq;
    using Xamarin.Forms;

    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            ViewModel = new MapPageViewModel();
            _positions = new List<Position>();

            InitializeComponent();

			PickButton.Clicked += (sender, e) => {
				/*
if (CrossMedia.Current.IsCameraAvailable && CrossMedia.Current.IsTakePhotoSupported)
            {
                // Supply media options for saving our photo after it's taken.
                var mediaOptions = new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Pickups",
                    Name = $"{DateTime.UtcNow}.jpg"
                };

                // Take a photo of the business receipt.
                var file = await CrossMedia.Current.TakePhotoAsync(mediaOptions);
            }
				*/
			};
        }

        public MapPageViewModel ViewModel { get; private set; }
        public Plugin.Geolocator.Abstractions.Position CurrentPosition { get; private set; }


        private bool _isMapReady = false;
        private ICollection<Position> _positions;

        public async Task SetupMap()
        {
            if (ViewModel.HasAddress)
            {
                MapControl.IsVisible = false;

                // set to a default position
                CurrentPosition = new Plugin.Geolocator.Abstractions.Position { Latitude = 9.932076, Longitude = -84.043890 };

                try
                {
                    CurrentPosition = await ViewModel.GetPosition();
                }
                catch
                {
                    ViewModel.DisplayGeocodingError();
                }

                MapControl.Pins.Clear();

                var pin = SetPin(CurrentPosition.Latitude, CurrentPosition.Longitude, ViewModel.DefaultLocationTitle ?? string.Empty, string.Empty);
                CenterTo(pin);

                MapControl.IsVisible = true;
                _isMapReady = true;
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (!_isMapReady)
            {
                await SetupMap();
            }
        }
        private void CenterTo(Pin pin)
        {
            const double ZOOM_MILES = 1;
            MapControl.MoveToRegion(MapSpan.FromCenterAndRadius(pin.Position, Distance.FromMiles(ZOOM_MILES)));
        }

        public void SetLocation(double latitude, double longitude, string title, string address)
        {
            var pin = SetPin(latitude, longitude, title, address);
            if (pin == null)
            {
                return;
            }
            CenterTo(pin);
        }

        private Pin SetPin(double latitude, double longitude, string location, string address)
        {
            var position = new Position(latitude, longitude);

            if (IsAlreadySet(position))
            {
                return null;
            }

            _positions.Add(position);

            var pin = new Pin
            {
                Type = PinType.Place,
                Position = position,
                Label = location,
                Address = address
            };
            MapControl.Pins.Add(pin);
			//
            return pin;
        }
        private bool IsAlreadySet(Position position)
        {
            return _positions.Any(item => item.Latitude.CompareTo(position.Latitude) == 0)
                && _positions.Any(item => item.Longitude.CompareTo(position.Longitude) == 0);
        }
    }
}
