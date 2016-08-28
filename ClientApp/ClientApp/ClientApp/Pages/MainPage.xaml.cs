namespace ClientApp
{
    using Pages;
    using Xamarin.Forms;
    using System.Linq;

    public partial class MainPage : MasterDetailPage
    {
        public MainPage(MapPage mapPage)
        {
            MapPage = mapPage;
			MapPage.MainPage = this;

            MenuItems = new[] {
                new NavigationItem { Title = MapPage.Title, NavigationCommand = new Command(() => ShowMap()) },
				new NavigationItem { Title = "Mis solicitudes", NavigationCommand = new Command(() => ShowPage(new ContentPage { Title = "Mis solicitues", Content = new Label { 
					Margin = new Thickness(2,0,0,0), Text = "No tienes solicitudes"}
				})) }
            };

            InitializeComponent();

            BindingContext = this;

            ListViewMenu.SelectedItem = MenuItems.FirstOrDefault();

			Detail = mapPage;
            ListViewMenu.ItemSelected += (sender, args) => {
                var menuItem = args.SelectedItem as NavigationItem;
                if (menuItem == null)
                {
                    return;
                }
                menuItem.NavigationCommand.Execute(sender);
            };
        }

        public MapPage MapPage { get; private set;}

        private void ShowMap()
        {
            PushPage(MapPage);
        }

        public void ShowPage(Page thePage)
        {
            IsPresented = false;

            Title = thePage.Title;
            Detail = thePage;
        }

        public async void PushPage(Page thePage)
        {
            IsPresented = false;
            Title = thePage.Title;

            await Navigation.PushAsync(thePage);
        }

        public NavigationItem[] MenuItems { get; private set; }
    }
}