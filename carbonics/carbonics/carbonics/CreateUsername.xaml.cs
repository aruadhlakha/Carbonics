using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace carbonics
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateUsername : ContentPage
	{
		public CreateUsername ()
		{
			InitializeComponent ();
		}

        private void SetUser_Clicked(object sender, EventArgs e)
        {
            if ((userent.Text == null) || (userent.Text == "")) return;
            Application.Current.Properties["username"] = userent.Text;
            MainPage page = new MainPage();
            Navigation.PushModalAsync(page);
        }
    }
}