using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace carbonics
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            if (!Application.Current.Properties.ContainsKey("username"))
                MainPage = new CreateUsername();
            else
                MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            int count = 0;
            for(int i = 0; i < 50; i++)
            {
                Application.Current.Properties.Remove("taskd" + i);
                Application.Current.Properties.Remove("taskc" + i);
            }
            if (MainPage is MainPage)
            {
                foreach (Task t in ((MainPage)MainPage).user.displayTasks())
                {
                    Application.Current.Properties["taskd" + count] = t.GetDesc();
                    Application.Current.Properties["taskc" + count] = t.xp();
                    count++;
                }
                count = 0;
                for (int i = 0; i < 50; i++)
                {
                    Application.Current.Properties.Remove("tommorowtaskd" + i);
                    Application.Current.Properties.Remove("tommorowtaskc" + i);
                }
                foreach (Task t in ((MainPage)MainPage).user.GetTomorrowTasks())
                {
                    Application.Current.Properties["tommorowtaskd" + count] = t.GetDesc();
                    Application.Current.Properties["tommorowtaskc" + count] = t.xp();
                    count++;
                }
            }
        }
        

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
