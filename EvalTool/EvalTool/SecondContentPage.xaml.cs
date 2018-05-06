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
                Score1 = (int)Score1.Value,
                Score2 = (int)Score2.Value,
                Score3 = (int)Score3.Value,
                Score4 = (int)Score4.Value,
                Score5 = (int)Score5.Value,
                Remarks = Remarks.Text,
               
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

        public void ChangeScore1(object sender, ValueChangedEventArgs e, Slider slider)
        {
            int score1 = (int)Score1.Value;
            string score1String = score1.ToString();
            Score1val.Text = $"User Experience Score: {score1String}";
        }

        public void ChangeScore2(object sender, ValueChangedEventArgs e, Slider slider)
        {
            int score2 = (int)Score2.Value;
            string score2String = score2.ToString();
            Score2val.Text = $"Implementation Score: {score2String}";
        }

        public void ChangeScore3(object sender, ValueChangedEventArgs e, Slider slider)
        {
            int score3 = (int)Score3.Value;
            string score3String = score3.ToString();
            Score3val.Text = $"Research Score: {score3String}";
        }

        public void ChangeScore4(object sender, ValueChangedEventArgs e, Slider slider)
        {
            int score4 = (int)Score4.Value;
            string score4String = score4.ToString();
            Score4val.Text = $"Presentation Score: {score4String}";
        }

        public void ChangeScore5(object sender, ValueChangedEventArgs e, Slider slider)
        {
            int score5 = (int)Score5.Value;
            string score5String = score5.ToString();
            Score5val.Text = $"Overall Score: {score5String}";
        }
    }
}