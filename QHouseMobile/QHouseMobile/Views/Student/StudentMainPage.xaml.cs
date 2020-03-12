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

        private int houseIndex = 0;

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

            try
            {
                houseIndex = 0;
                getHouses();
                
            } catch(Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        async void getHouses()
        {
            var housesJSON = await httpClient.GetStringAsync("/house");
            houseList = JsonConvert.DeserializeObject<List<Classes.House>>(housesJSON);

            updateHouseDisplay();  //This works its just really slow.  Should probably fix later
        }

        void updateHouseDisplay()
        {
            Classes.House h = houseList.ElementAt(houseIndex);
            HouseNumBedrooms = h.numBedrooms.ToString();
            HouseNumBathrooms = h.numBathrooms.ToString();
            HouseRent = h.rent.ToString();
            HouseAddress = h.address;
        }

        void LeftButtonClicked(object sender, EventArgs e)
        {
            houseIndex = houseIndex == 0 ? houseList.Count - 1 : houseIndex - 1;
            updateHouseDisplay();
        }

        void RightButtonClicked(object sender, EventArgs e)
        {
            houseIndex = houseIndex == houseList.Count - 1 ? 0 : houseIndex + 1;
            updateHouseDisplay();
        }
    }
}