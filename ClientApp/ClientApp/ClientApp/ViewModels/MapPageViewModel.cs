namespace ClientApp.ViewModels
{
    using Plugin.Geolocator;
    using Plugin.Geolocator.Abstractions;
    using System.Linq;
    using System.Threading.Tasks;

    public class MapPageViewModel : BaseNavigationViewModel
    {
        public string DefaultLocationTitle { get; set; }
        public bool HasAddress => true;

        object _model;
        public object Model
        {
            get { return _model; }
            set
            {
                _model = value;
                OnPropertyChanged();
            }
        }

        public void DisplayGeocodingError()
        {/*
                MessagingService.Current.SendMessage<MessagingServiceAlert>(MessageKeys.DisplayAlert, new MessagingServiceAlert()
                {
                    Title = "Geocoding Error",
                    Message = "Please make sure the address is valid, or that you have a network connection.",
                    Cancel = "OK"
                });

                IsBusy = false;*/
        }

        public async Task<Position> GetPosition()
        {
            if (!HasAddress)
                return new Position();

            IsBusy = true;

            var position = await CrossGeolocator.Current.GetPositionAsync(10000);

            IsBusy = false;

            return position;
        }

        static bool AddressBeginsWithNumber(string address)
        {
            return !string.IsNullOrWhiteSpace(address) && char.IsDigit(address.ToCharArray().First());
        }

        static string GetAddressWithRoundedStreetNumber(string address)
        {
            var endingIndex = GetEndingIndexOfNumericPortionOfAddress(address);

            if (endingIndex == 0)
                return address;

            int originalNumber = 0;
            int roundedNumber = 0;

            int.TryParse(address.Substring(0, endingIndex + 1), out originalNumber);

            if (originalNumber == 0)
                return address;

            roundedNumber = 0; // originalNumber.RoundToLowestHundreds();

            return address.Replace(originalNumber.ToString(), roundedNumber.ToString());
        }

        static int GetEndingIndexOfNumericPortionOfAddress(string address)
        {
            int endingIndex = 0;

            for (int i = 0; i < address.Length; i++)
            {
                if (char.IsDigit(address[i]))
                    endingIndex = i;
                else
                    break;
            }

            return endingIndex;
        }
    }
}