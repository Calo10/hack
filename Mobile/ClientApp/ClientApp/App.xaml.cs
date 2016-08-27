[assembly: Xamarin.Forms.Xaml.XamlCompilation(Xamarin.Forms.Xaml.XamlCompilationOptions.Compile)]
namespace ClientApp
{
    using Pages;

    public partial class App
    {
        public App()
        {
            InitializeComponent();

            TheMapPage = new MapPage();
            MainPage = TheMapPage;
        }

        public MapPage TheMapPage { get; private set; }

        protected async override void OnStart()
        {
            await TheMapPage.SetupMap();
        }
    }
}