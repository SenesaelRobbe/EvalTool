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
	public partial class SecondContentPage : ContentPage
	{
		public SecondContentPage ()
		{
			InitializeComponent ();
		}

        public void StoreAll(object sender, EventArgs e)
        {
            var TeamAndScores = new TeamAndScores
            {
                Teamname = Tname.Text,
                Username = Uname.Text,
                UserExp = UserExp.Value,
                Implement = Implement.Value,
                Research = Research.Value,
                Presentation = Presentation.Value,
                Overall = Overall.Value,
                Remarks = Remarks.Text 
            };
        }

        public void ChangeText(object sender, EventArgs e)
        {

        }
	}
}