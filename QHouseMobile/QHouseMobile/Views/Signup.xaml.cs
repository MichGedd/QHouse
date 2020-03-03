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

        bool isStudent = true;

        public Signup()
        {
            InitializeComponent();
            httpClient.BaseAddress = new Uri(ApplicationResources.BaseURI);
        }

        void NameChanged(object sender, TextChangedEventArgs e)
        {
            var text = ((Entry)sender).Text;
            name = text;
        }
        void EmailChanged(object sender, TextChangedEventArgs e)
        {
            var text = ((Entry)sender).Text;
            email = text;
        }
        void PasswordChanged(object sender, TextChangedEventArgs e)
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

                String apiEndpoint = isStudent ? "student/create" : "landlord/create";

                try
                {
                    var response = await httpClient.PostAsync(apiEndpoint, content);
                    var responseString = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine(responseString);
                    await Navigation.PopAsync();

                } catch(Exception exception)
                {
                    Debug.WriteLine(exception);
                }

                
            }
        }

        void OnToggle(object sender, ToggledEventArgs e)
        {
            isStudent = e.Value;
            Debug.WriteLine(isStudent);
        }
    }
}