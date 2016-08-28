using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ClientApp.Pages
{
    public partial class PickPage : ContentPage
    {
        public PickPage()
        {
            InitializeComponent();

			CompleteButton.Clicked += (sender, e) => {
				CompleteButton.Text = "Enviando...";
				CompleteButton.IsEnabled = false;

				Navigation.RemovePage(Navigation.NavigationStack.Last());
			};
        }
    }
}
