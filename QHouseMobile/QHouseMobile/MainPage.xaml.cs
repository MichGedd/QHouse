using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QHouseMobile
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void OnSignUpClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Signup());
        }

        async void OnLoginClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Login());
        }
    }
}
