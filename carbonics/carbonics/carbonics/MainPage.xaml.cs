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
        int exp = 0;
        int level = 1;


        public MainPage()
        {
            page = this;
            InitializeComponent();
            taskStack = TaskStack;
            for(int i = 0; i < 5; i++)
            {
                taskStack.Children.Add(new TaskBoxGUI("New Task " + i));
            }
            if (Application.Current.Properties.ContainsKey("level")) 
                level = (int)Application.Current.Properties["level"];
            if (Application.Current.Properties.ContainsKey("exp"))
                exp = (int)Application.Current.Properties["exp"];
            UpdateLvView();
        }

        public void Test_Clicked(object sender, EventArgs e)
        {
            lBox.WidthRequest = 20;
        }

        public void IncExperience(int inc)
        {
            exp += inc;
            CalcLev();
            UpdateLvView();
        }

        private void UpdateLvView()
        {
            LevelLabel.Text = "" + level;
            lBox.WidthRequest = 200 * ((double)exp / GetLevelReq());
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
