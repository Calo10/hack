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

            Root = new MainPage();
            TheMapPage = new MapPage();
            MainNavigationPage = new NavigationPage(Root);
            MainPage = MainNavigationPage;
        }

        public NavigationPage MainNavigationPage { get; set; }
        public MainPage Root { get; private set; }
        public MapPage TheMapPage { get; private set; }
       
        /*
        protected async override void OnStart()
        {
            await TheMapPage.SetupMap();
        }*/
    }
}