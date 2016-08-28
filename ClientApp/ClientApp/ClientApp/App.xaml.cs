[assembly: Xamarin.Forms.Xaml.XamlCompilation(Xamarin.Forms.Xaml.XamlCompilationOptions.Compile)]
namespace ClientApp
{
    using Xamarin.Forms;
    using Pages;

    public partial class App :Application
    {
        public App()
        {
            InitializeComponent();

			TheMapPage = new MapPage();
			Root = new MainPage (TheMapPage);
			MainNavigationPage = new NavigationPage(Root) { BarBackgroundColor = Color.FromHex("#0071BC") };
            MainPage = MainNavigationPage;
        }

        public NavigationPage MainNavigationPage { get; set; }
        public MainPage Root { get; private set; }
        public MapPage TheMapPage { get; private set; }
       
        protected async override void OnStart()
        {
            await TheMapPage.SetupMap();
        }
    }
}