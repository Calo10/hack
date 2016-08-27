using System.Windows.Input;

namespace ClientApp
{
    public class NavigationItem
    {
        public ICommand NavigationCommand { get; set; }
        public string Title { get; internal set; }
    }
}