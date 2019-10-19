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
            BackgroundColor = Color.LawnGreen;
            HeightRequest = 10;
            
            WidthRequest = 200 * 0.5;
        }
    }
}
