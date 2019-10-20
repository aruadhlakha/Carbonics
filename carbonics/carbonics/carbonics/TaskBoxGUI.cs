using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace carbonics
{
    class TaskBoxGUI : Grid
    {
        public int experience = 20;
        Task tk;
        public TaskBoxGUI(string t)
        {
            Children.Add(new Label { Text = t, BackgroundColor = Color.Gold, HeightRequest = 60, FontSize = 8, HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center });
            var fail = new Button { Text = "Not quite", FontSize = 8, BackgroundColor = Color.LightSteelBlue, HeightRequest = 60, WidthRequest = 60, HorizontalOptions = LayoutOptions.Start };
            Children.Add(fail);
            fail.Clicked += new EventHandler((object sender, EventArgs args) => { Destroy(false); });
            var pass = new Button { Text = "Did it!", FontSize = 8, BackgroundColor = Color.LightSteelBlue, HeightRequest = 60, WidthRequest = 60, HorizontalOptions = LayoutOptions.End };
            Children.Add(pass);
            pass.Clicked += new EventHandler((object sender, EventArgs args) => { Destroy(true); });

        }

        public TaskBoxGUI(Task task)
        {
            tk = task;
            experience = task.xp();
            Children.Add(new Label { Text = task.GetDesc(), BackgroundColor = Color.Gold, FontSize = 7, HeightRequest = 60, HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center });
            var fail = new Button { Text = "Not quite", FontSize = 8, BackgroundColor = Color.LightSteelBlue, HeightRequest = 60, WidthRequest = 60, HorizontalOptions = LayoutOptions.Start };
            Children.Add(fail);
            fail.Clicked += new EventHandler((object sender, EventArgs args) => { Destroy(false); });
            var pass = new Button { Text = "Did it!", FontSize = 8, BackgroundColor = Color.LightSteelBlue, HeightRequest = 60, WidthRequest = 60, HorizontalOptions = LayoutOptions.End };
            Children.Add(pass);
            pass.Clicked += new EventHandler((object sender, EventArgs args) => { Destroy(true); });

        }

        private void Destroy(bool pass)
        {
            if (pass)
            {
                MainPage.page.IncExperience(experience);
            } else MainPage.page.IncExperience(experience / 4);
            MainPage.page.user.RemoveTask(tk);
            MainPage.taskStack.Children.Remove(this);
            MainPage.taskStack.ForceLayout();
        }
    }
}
