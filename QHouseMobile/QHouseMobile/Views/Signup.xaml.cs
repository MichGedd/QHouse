using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QHouseMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Signup : ContentPage
    {
        static readonly HttpClient httpClient = new HttpClient();

        string name, email, password;

        public Signup()
        {
            InitializeComponent();
        }

        void NameCompleted(object sender, EventArgs e)
        {
            var text = ((Entry)sender).Text;
            name = text;
        }
        void EmailCompleted(object sender, EventArgs e)
        {
            var text = ((Entry)sender).Text;
            email = text;
        }
        void PasswordCompleted(object sender, EventArgs e)
        {
            var text = ((Entry)sender).Text;
            password = text;
        }

        async void OnSignUpClicked(object sender, EventArgs e)
        {
            if(!String.Equals(name, "") && !String.Equals(password, "") && !String.Equals(email, ""))
            {
                var values = new Dictionary<string, string>
                {
                    {"name", name },
                    {"email", email },
                    {"password", password }
                };

                //var content = new FormUrlEncodedContent(values);

                string payload = JsonConvert.SerializeObject(values);
                var content = new StringContent(payload, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("http://10.0.2.2:8080/students", content);
                var responseString = await response.Content.ReadAsStringAsync();

                Debug.WriteLine(responseString);
            }
        }
    }
}