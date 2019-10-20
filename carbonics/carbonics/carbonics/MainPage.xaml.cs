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
        public static StackLayout taskStack;
        public static MainPage page;
        public User user;
        int exp = 0;
        int level = 1;
        int timeLeft = 1000;

        public MainPage()
        {
            page = this;
            InitializeComponent();
            taskStack = TaskStack;
            if(Application.Current.Properties.ContainsKey("time")) 
                timeLeft = (int)Application.Current.Properties["time"];
            if (Application.Current.Properties.ContainsKey("level")) 
                level = (int)Application.Current.Properties["level"];
            if (Application.Current.Properties.ContainsKey("exp"))
                exp = (int)Application.Current.Properties["exp"];
            user = new User(level, exp, 10, "Aryan", timeLeft);
            var taskLs = user.displayTasks();
            RefreshScreen();
        }

        public void NDTasks_Clicked(object sender, EventArgs e)
        {
            var proposal = new TaskProposal();
            Navigation.PushModalAsync(proposal);
        }

        public void IncExperience(int inc)
        {
            exp += inc;
            CalcLev();
            UpdateLvView();
        }

        public void RefreshScreen()
        {
            UpdateLvView();
            var taskLs = user.displayTasks();
            foreach (Task tk in taskLs)
            {
                if (tk != null)
                    taskStack.Children.Add(new TaskBoxGUI(tk));
            }
        }

        private void UpdateLvView()
        {
            LevelLabel.Text = "" + level;
            lBox.WidthRequest = 200 * ((double)exp / GetLevelReq());
            expfrac.Text = exp + "/" + GetLevelReq();
        }

        private int GetLevelReq()
        {
            return level * 100;
        }

        private void CalcLev()
        {
            var tmp = level;
            level = (exp / GetLevelReq()) + level;
            if (tmp != level) exp = 0;
            Application.Current.Properties["level"] = level;
            Application.Current.Properties["exp"] = exp;
        }
    }
}
