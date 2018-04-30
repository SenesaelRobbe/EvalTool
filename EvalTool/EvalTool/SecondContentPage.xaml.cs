//using Org.Apache.Http.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        

        public async Task StoreAndPost(object sender, EventArgs e)
        {
            HttpClient http = new HttpClient();
            Uri Uri = new Uri("http://evaluation.cursusweb.be/api/evaluation");

            var Json = JsonConvert.SerializeObject(new TeamAndScores
            {
                Username = Uname.Text,
                GroupName = Teamname.Text,
                UserExp = UserExp.Value,
                Implement = Implement.Value,
                Research = Research.Value,
                Presentation = Presentation.Value,
                Overall = Overall.Value,
                Remarks = Remarks.Text
            });
            var Content = new StringContent(Json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            response = await http.PostAsync(Uri, Content);

            if (response.IsSuccessStatusCode)
            {

                await DisplayAlert("succes", "Your evaluation was posted ", "Done");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("failed", "Your evaluation failed to post ", "Done");
            }
    }

        public void ChangeText(object sender, ValueChangedEventArgs e, Slider slider)
        {
           //var val = slider.Value;
            
           // uexp.Text = val.ToString();
        }
	}
}