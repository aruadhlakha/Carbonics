using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace carbonics
{
    class LevelBox : BoxView
    {
        public LevelBox()
        {
            VerticalOptions = LayoutOptions.Center;
            HorizontalOptions = LayoutOptions.Start;
            BackgroundColor = Color.DarkSeaGreen;
            HeightRequest = 10;
            
            WidthRequest = 0;
        }
    }
}
