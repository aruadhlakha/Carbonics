using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace carbonics
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TaskProposal : ContentPage
	{
		public TaskProposal ()
		{
			InitializeComponent ();
            Task[] tks = MainPage.page.user.fDisplayTasks();
            foreach(Task tk in tks) {
                Stacker.Children.Add(new TaskBoxGUI(tk));
            }
		}
	}
}