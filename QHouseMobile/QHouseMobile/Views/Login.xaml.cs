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
    public partial class Login : ContentPage
    {
        private string email, password;
        static readonly HttpClient httpClient = new HttpClient();

        bool isStudent = true;

        public Login()
        {
            InitializeComponent();
            httpClient.BaseAddress = new Uri(ApplicationResources.BaseURI);
        }

        void EmailChanged(object sender, EventArgs e)
        {
            email = ((Entry)sender).Text;
        }

        void PasswordChanged(object sender, EventArgs e)
        {
            password = ((Entry)sender).Text;
        }

        void OnSwitchToggled(object sender, ToggledEventArgs e)
        {
            isStudent = e.Value;
        }

        async void OnLoginClicked(object sender, EventArgs e)
        {
            if (!String.Equals(password, "") && !String.Equals(email, ""))
            {
                var values = new Dictionary<String, String>
                {
                    {"email", email },
                    {"password", password }
                };

                string payload = JsonConvert.SerializeObject(values);
                var content = new StringContent(payload, Encoding.UTF8, "application/json");

                try
                {
                    string apiEndpoint = isStudent ? "student/login" : "landlord/login";

                    var response = await httpClient.PostAsync(apiEndpoint, content);
                    var id = await response.Content.ReadAsStringAsync();

                    Debug.WriteLine(id);

                    if (id.Equals("false"))
                    {
                        throw new ArgumentException("Student with that email doesnt exist!");
                    }

                    if (App.Current.Properties.ContainsKey("id"))
                        App.Current.Properties["id"] = id;
                    else
                        App.Current.Properties.Add("id", id);

                    string userType = isStudent ? "student" : "landlord";

                    if (App.Current.Properties.ContainsKey("type"))
                        App.Current.Properties["type"] = userType;
                    else
                        App.Current.Properties.Add("type", userType);


                } catch (Exception exception)
                {
                    Debug.WriteLine(exception);
                }
            }
        }

    }
}