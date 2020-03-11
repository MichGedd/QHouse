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
            await Navigation.PushAsync(new LandlordCreateHousePage());
        }
    }
}