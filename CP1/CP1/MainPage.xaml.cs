using CP1.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CP1
{
    public partial class MainPage : ContentPage
    {

        Dictionary<string, double> Material = new Dictionary<string, double>();
        double dens = 0;

        public MainPage()
        {
            InitializeComponent();
            AdMobControl admobcontrol = new AdMobControl()
            {
                AdUnitId = "ca-app-pub-9496442035641158/7670378711"
            };
            //Label adLabel = new Label() { Text = "Ads Will Display" };
            //Content = new StackLayout()
            //{ Children = { admobcontrol }};
            Material.Add("Aluminium", 2.713);
            Material.Add("Steel", 7.861);
            Material.Add("Stainless Steel", 7.85);
            Material.Add("Copper", 8.96);

            foreach (string ChooseMat in Material.Keys)
            {
                picker.Items.Add(ChooseMat);
            }
        }
        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            string mat;
            if (picker.SelectedIndex == -1)
            {

                mat = "Aluminium";
            }
            else
            {
                mat = picker.Items[picker.SelectedIndex];
               
            }
            dens = Material[mat];

        }

        private async void OnButtonClicked(object sender, EventArgs args)
        {
            if (dens == 0)
            {
                await DisplayAlert("Alert", "Malzemeyi Seçiniz", "OK");
            }
            else
            {
                await Navigation.PushAsync(new Page1(dens));
            }
        }

    }
}
