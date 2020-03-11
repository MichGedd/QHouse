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

                    apiEndpoint = isStudent ? "student" : "landlord";
                    apiEndpoint = $"{apiEndpoint}/{id}";
                    Debug.WriteLine(apiEndpoint);
                    var user = await httpClient.GetStringAsync(apiEndpoint);

                    Debug.WriteLine(user);

                    if (App.Current.Properties.ContainsKey("user"))
                        App.Current.Properties["user"] = user;
                    else
                        App.Current.Properties.Add("user", user);

                    /*Classes.Student student = JsonConvert.DeserializeObject<Classes.Student>(user);
                    Debug.WriteLine("name: " + student.name + " email: " + student.email);*/

                    if (isStudent)
                        await Navigation.PushAsync(new StudentMainPage());
                    else
                        await Navigation.PushAsync(new LandlordMainPage());


                } catch (Exception exception)
                {
                    Debug.WriteLine(exception);
                }
            }
        }

    }
}