using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace carbonics
{
    class TaskCheckBox : Grid
    {
        bool selected;
        static int numSelected;
        Task task;

        public bool GetSelected()
        {
            return selected;
        }

        public Task GetTask()
        {
            return task;
        }
        public TaskCheckBox(Task t)
        {
            numSelected = Math.Min(MainPage.page.user.GetTomorrowTasks().Count, 5);
            task = t;
            Children.Add(new Label { Text = t.GetDesc(), FontSize = 10, BackgroundColor = Color.Gold, HeightRequest = 60,
                HorizontalTextAlignment = TextAlignment.Start, VerticalTextAlignment = TextAlignment.Center });
            var b = new Button { Text = "Not Selected", FontSize = 7, BackgroundColor = Color.LightSteelBlue, HeightRequest = 60,
                WidthRequest = 60, HorizontalOptions = LayoutOptions.End };
            Children.Add(b);
            b.Clicked += new EventHandler((object sender, EventArgs args) => {
                if (selected) numSelected--;
                selected = !selected;
                if (numSelected == 5) selected = false;
                else if(selected) numSelected++;
                b.Text = selected ? "Selected" : "Not Selected";
                b.BackgroundColor = selected ? Color.LightSeaGreen : Color.LightSteelBlue;
            });
        }
    }
}
