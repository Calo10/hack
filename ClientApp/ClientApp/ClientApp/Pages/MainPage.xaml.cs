namespace ClientApp
{
    using Pages;
    using Xamarin.Forms;
    using System.Linq;

    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            MenuItems = new[] {
                new NavigationItem { Title = "My app", NavigationCommand = new Command(() => ShowPage(new ContentPage())) },
                new NavigationItem { Title = MapPage.Title, NavigationCommand = new Command(() => ShowMap()) }
            };

            InitializeComponent();

            BindingContext = this;

            ListViewMenu.SelectedItem = MenuItems.FirstOrDefault();

            ListViewMenu.ItemSelected += (sender, args) => {
                var menuItem = args.SelectedItem as NavigationItem;
                if (menuItem == null)
                {
                    return;
                }
                menuItem.NavigationCommand.Execute(sender);
            };
        }

        public MapPage MapPage { get; set;}

        private void ShowMap()
        {
            PushPage(MapPage);
        }

        private void ShowPage(Page thePage)
        {
            IsPresented = false;

            Title = thePage.Title;
            Detail = thePage;
        }

        private async void PushPage(Page thePage)
        {
            IsPresented = false;
            Title = thePage.Title;

            await Navigation.PushAsync(thePage);
        }

        public NavigationItem[] MenuItems { get; private set; }
    }
}