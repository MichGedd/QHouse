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
    public partial class LandlordCreateHousePage : ContentPage
    {
        HttpClient httpClient = new HttpClient();
        Classes.Landlord user;

        string numBathrooms, numBedrooms, rent, address;

        public LandlordCreateHousePage()
        {
            InitializeComponent();

            httpClient.BaseAddress = new Uri(ApplicationResources.BaseURI);
            var userJSON = App.Current.Properties["user"] as string;

            user = JsonConvert.DeserializeObject<Classes.Landlord>(userJSON);
        }

        void NumBedroomsChanged(object sender, EventArgs e)
        {
            numBedrooms = ((Entry)sender).Text;
        }

        void NumBathroomsChanged(object sender, EventArgs e)
        {
            numBathrooms = ((Entry)sender).Text;
        }

        void RentPriceChanged(object sender, EventArgs e)
        {
            rent = ((Entry)sender).Text;
        }

        void AddressChanged(object sender, EventArgs e)
        {
            address = ((Entry)sender).Text;
        }

        async void OnCreateHouse(object sender, EventArgs e)
        {
            var values = new Dictionary<String, String>
            {
                {"numBedrooms", numBedrooms },
                {"numBathrooms", numBathrooms },
                {"rent", rent },
                {"address", address }
            };

            string payload = JsonConvert.SerializeObject(values);
            var content = new StringContent(payload, Encoding.UTF8, "application/json");

            try
            {
                string apiEndpoint = $"house/create?parentID={user.id}";
                var response = await httpClient.PostAsync(apiEndpoint, content);
                var responseString = await response.Content.ReadAsStringAsync();

                Debug.WriteLine(responseString);

                await Navigation.PopAsync();

            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
            }
        }
    }
}