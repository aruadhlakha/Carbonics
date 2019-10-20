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
        int timeLeft = 30;
        DateTime startTime;

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
            startTime = DateTime.Now;
            user = new User(level, exp, 10, "Aryan", timeLeft);
            var taskLs = user.displayTasks();
            RefreshScreen();
            Device.StartTimer(TimeSpan.FromSeconds(1), UpdateTime);
            UpdateTime();
        }

        public void NDTasks_Clicked(object sender, EventArgs e)
        {
            if(!TaskProposal.opened)
            {
                var proposal = new TaskProposal();
                Navigation.PushModalAsync(proposal);
            }
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
            taskStack.Children.Clear();
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

        public void ResetDay()
        {
            user.ResetTasks();
            RefreshScreen();
        }

        public bool UpdateTime()
        {
            timeLeft -= 1;
            if (timeLeft <= 0)
            {
                timeLeft = 30;
                ResetDay();
            }
            timeTill.Text = timeLeft / 3600 + " hours, " + timeLeft / 60 + " minutes and " + timeLeft + " seconds till reset";
            return true;
        }
    }
}
