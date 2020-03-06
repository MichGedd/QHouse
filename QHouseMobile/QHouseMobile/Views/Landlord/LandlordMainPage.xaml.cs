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
    public partial class LandlordMainPage : ContentPage
    {

        Classes.Landlord user;
        HttpClient httpClient = new HttpClient();

        public LandlordMainPage()
        {
            InitializeComponent();
            httpClient.BaseAddress = new Uri(ApplicationResources.BaseURI);
            var userJSON = App.Current.Properties["user"] as string;

            user = JsonConvert.DeserializeObject<Classes.Landlord>(userJSON);

        }

        async void OnCreateHouse(object sender, EventArgs e)
        {
            Classes.House testHouse = new Classes.House();
            testHouse.numBedrooms = 4;
            testHouse.numBathrooms = 1;

            var values = new Dictionary<String, String>
            {
                {"numBedrooms", testHouse.numBedrooms.ToString() },
                {"numBathrooms", testHouse.numBathrooms.ToString() }
            };

            string payload = JsonConvert.SerializeObject(values);
            var content = new StringContent(payload, Encoding.UTF8, "application/json");

            try
            {
                string apiEndpoint = $"house/create?parentID={user.id}";
                var response = await httpClient.PostAsync(apiEndpoint, content);
                var responseString = await response.Content.ReadAsStringAsync();

                Debug.WriteLine(responseString);

            } catch (Exception exception)
            {
                Debug.WriteLine(exception);
            }
        }
    }
}