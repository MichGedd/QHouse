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
    public partial class StudentMainPage : ContentPage
    {
        private string houseNumBedrooms;
        private string houseNumBathrooms;
        private string houseRent;
        private string houseAddress;

        private Classes.Student user;

        HttpClient httpClient = new HttpClient();
        List<Classes.House> houseList;

        public string HouseNumBedrooms
        {
            get { return houseNumBedrooms; }
            set
            {
                houseNumBedrooms = value;
                OnPropertyChanged(nameof(HouseNumBedrooms));
            }
        }
        public string HouseNumBathrooms
        {
            get { return houseNumBathrooms; }
            set
            {
                houseNumBathrooms = value;
                OnPropertyChanged(nameof(HouseNumBathrooms));
            }
        }
        public string HouseRent
        {
            get { return houseRent; }
            set
            {
                houseRent = value;
                OnPropertyChanged(nameof(HouseRent));
            }
        }
        public string HouseAddress
        {
            get { return houseAddress; }
            set
            {
                houseAddress = value;
                OnPropertyChanged(nameof(HouseAddress));
            }
        }



        public StudentMainPage()
        {
            InitializeComponent();
            BindingContext = this;
            httpClient.BaseAddress = new Uri(ApplicationResources.BaseURI);

            //var userJSON = App.Current.Properties["user"] as string;

            //user = JsonConvert.DeserializeObject<Classes.Student>(userJSON);

            HouseNumBedrooms = "4";
            HouseNumBathrooms = "4";
            HouseRent = "$1500.00";
            HouseAddress = "123 Street St";

            try
            {
                //string httpGet = httpClient.GetStringAsync("/house").Wait();
                getHouses();
            } catch(Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        public async void getHouses()
        {
            var housesJSON = await httpClient.GetStringAsync("/house");

            houseList = JsonConvert.DeserializeObject<List<Classes.House>>(housesJSON);

            Debug.WriteLine(housesJSON);

            foreach(Classes.House h in houseList)
            {
                Debug.WriteLine(h.rent);
            }

        }
    }
}