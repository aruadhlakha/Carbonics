﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace carbonics
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskProposal : ContentPage
    {
        public static bool opened;
        public TaskProposal()
        {
            opened = true;
            InitializeComponent();
            Task[] tks = MainPage.page.user.fDisplayTasks();
            foreach (Task tk in tks) {
                Stacker.Children.Add(new TaskCheckBox(tk));
            }
        }

        private void Confirmer_Clicked(object sender, EventArgs e)
        {
            var props = Application.Current.Properties;
            if (props.ContainsKey("privacy") && (bool)props["privacy"] && props.ContainsKey("username") && props.ContainsKey("exp") && props.ContainsKey("level"))
            {
                IFirebaseConfig config = new FirebaseConfig
                {
                    AuthSecret = "sl8xzZIXaxap45WOhfBWX50q9IM0nmziqjtaYwtt",
                    BasePath = "https://xamarinapp-256505.firebaseio.com/"
                };
                IFirebaseClient client;

                client = new FireSharp.FirebaseClient(config);
                //client.Push("/MyTestData", new Tuple<string, int, int, int>(data.username, data.xp, data.level, (data.level-1) * 100 + data.xp));
                client.Push("/MyTestData", new UserData((string)props["username"], (int)props["exp"], (int)props["level"]));
            }

            User user = MainPage.page.user;

            System.Diagnostics.Debug.WriteLine("before " + user.GetTomorrowTasks().Count);
            foreach (TaskCheckBox box in Stacker.Children)
            {
                if (box.GetSelected())
                    user.selectTasks(box.GetTask());
            }
            System.Diagnostics.Debug.WriteLine("after " + user.GetTomorrowTasks().Count);
            opened = false;
            Navigation.PopModalAsync();
            MainPage.page.RefreshScreen();
        }

        class UserData 
        {
            public string Username;
            public int Experience;
            public int Level;
            public int TotalExperience;
            
            public UserData(string username, int exp, int level)
            {
                this.Username = username;
                this.Experience = exp;
                this.Level = level;
                TotalExperience = (level - 1) * 100 + exp;
            }
        }

        struct DBData
        {
            public DBData(string u, int x, int l)
            {
                username = u;
                xp = x;
                level = l;
            }
            public string username;
            public int xp;
            public int level;
        }
    }
}