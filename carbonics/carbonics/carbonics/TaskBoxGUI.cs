using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;


namespace carbonics
{
    class TaskBoxGUI : Grid
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "sl8xzZIXaxap45WOhfBWX50q9IM0nmziqjtaYwtt",
            BasePath = "https://xamarinapp-256505.firebaseio.com/"
        };
        IFirebaseClient client;
        public int experience = 20;

        public TaskBoxGUI(string t)
        {
            client = new FireSharp.FirebaseClient(config);
            data_to_upload ={
                'username': username
                'XP':xp
    }
            client.Push("/MyTestData", data_to_uploa);
            Children.Add(new Label { Text = t, BackgroundColor = Color.Gold, HeightRequest = 60, HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center });
            var fail = new Button { Text = "Not quite", FontSize = 8, BackgroundColor = Color.LightSteelBlue, HeightRequest = 60, WidthRequest = 60, HorizontalOptions = LayoutOptions.Start };
            Children.Add(fail);
            fail.Clicked += new EventHandler((object sender, EventArgs args) => { Destroy(false); });
            var pass = new Button { Text = "Did it!", FontSize = 8, BackgroundColor = Color.LightSteelBlue, HeightRequest = 60, WidthRequest = 60, HorizontalOptions = LayoutOptions.End };
            Children.Add(pass);
            pass.Clicked += new EventHandler((object sender, EventArgs args) => { Destroy(true); });
        }

        public TaskBoxGUI(Task task)
        {
            experience = task.xp();
            Children.Add(new Label { Text = task.GetDesc(), BackgroundColor = Color.Gold, HeightRequest = 60, HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center });
            var fail = new Button { Text = "Not quite", FontSize = 8, BackgroundColor = Color.LightSteelBlue, HeightRequest = 60, WidthRequest = 60, HorizontalOptions = LayoutOptions.Start };
            Children.Add(fail);
            fail.Clicked += new EventHandler((object sender, EventArgs args) => { Destroy(false); });
            var pass = new Button { Text = "Did it!", FontSize = 8, BackgroundColor = Color.LightSteelBlue, HeightRequest = 60, WidthRequest = 60, HorizontalOptions = LayoutOptions.End };
            Children.Add(pass);
            pass.Clicked += new EventHandler((object sender, EventArgs args) => { Destroy(true); });

        }

        private void Destroy(bool pass)
        {
            if(pass)
            {

            }
            MainPage.taskStack.Children.Remove(this);
            MainPage.taskStack.ForceLayout();
        }
    }
}
