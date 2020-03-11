using System;
using System.Collections.Generic;
using System.Linq;
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
            HouseNumBedrooms = "4";
            HouseNumBathrooms = "4";
            HouseRent = "$1500.00";
            HouseAddress = "123 Street St";
        }
    }
}