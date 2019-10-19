using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace carbonics
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Test_Clicked(object sender, EventArgs e)
        {
            lBox.WidthRequest = 50;
        }
    }
}
