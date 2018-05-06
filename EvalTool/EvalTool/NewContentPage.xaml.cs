using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EvalTool
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewContentPage : ContentPage
	{

        public NewContentPage ()
		{
			InitializeComponent ();
		}

        async public void SwitchPage()
        {
            var uname = UsernameEntry.Text;
            var tname = TeamnameEntry.Text;

            var Teaminfo = new Teaminfo
            {
                Username = UsernameEntry.Text,
                Teamname = TeamnameEntry.Text
            };

            if ((uname == null || tname == null))
            {
               await DisplayAlert("Fault!", "Your username or the groupname seems to be empty!", "Ok!");
            } else
            {
                var nextPage = new SecondContentPage();
                nextPage.BindingContext = Teaminfo;

                await Navigation.PushAsync(nextPage);
            }
        }

        //THESE WERE TESTS

        //public void StoreUsername(object sender, EventArgs e)
        //{
        //    string text = UsernameEntry.Text ;
        //    ShowName.Text = text;
        //}

        //public void StoreTeamname(object sender, EventArgs e)
        //{
        //    string text = TeamnameEntry.Text;
        //    ShowTeam.Text = text;
        //}
	}
}