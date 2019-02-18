using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CP1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
        Dictionary<string, Tuple<List<string>, Func<double, double, double, double, double, double>, double>> calculators = new Dictionary<string, Tuple<List<string>, Func<double, double, double, double, double, double>, double>>();
        double den;
        public Page1 ()
        {
        
        }
		public Page1 (double dens)
		{
			InitializeComponent ();
            this.den = dens;
            List<string> ME1 = new List<string>() { "İç Çap", "Dış Çap", "Kalınlık", "Metraj", "mm", "mm", "mm", "m" };
            List<string> ME2 = new List<string>() { "Miktar", "En", "Kalınlık", "Metraj", "kg", "mm", "mm", "m" };
            List<string> DI1 = new List<string>() { "İç Çap", "En", "Miktar", "Dış Çap", "mm", "mm", "kg", "mm" };
            List<string> DI2 = new List<string>() { "İç Çap", "Metraj", "Kalınlık", "Dış Çap", "mm", "m", "mm", "mm" };
            List<string> IC1 = new List<string>() { "Miktar", "Dış Çap", "En", "İç Çap", "kg", "mm", "mm", "mm" };
            List<string> IC2 = new List<string>() { "Metraj", "Dış Çap", "Kalınlık", "İç Çap", "m", "mm", "mm", "mm" };
            List<string> KA1 = new List<string>() { "Miktar", "Metraj", "En", "Kalınlık", "kg", "m", "mm", "mm" };
            List<string> KA2 = new List<string>() { "İç Çap", "Dış Çap", "Metraj", "Kalınlık", "mm", "mm", "m", "mm" };
            List<string> MI1 = new List<string>() { "Metraj", "En", "Kalınlık", "Miktar", "m", "mm", "mm", "kg" };
            List<string> MI2 = new List<string>() { "İç Çap", "Dış Çap", "En", "Miktar", "mm", "mm", "mm", "kg" };
            List<string> BO1 = new List<string>() { "Miktar", "Kalınlık", "B.Kalınlık", "Kaplama", "Boya Miktarı", "Kg", "mm", "μm", "m2/1kg1μm", "Kg" };
            List<string> BO2 = new List<string>() { "Miktar", "Kalınlık", "B.Kalınlık", "Boya Cinsi", "Boya Miktarı", "Kg", "mm", "μm", "Reçine", "Kg"};
            List<string> FA1 = new List<string>() { "F.İç Çap", "F.Dış Çap", "F.Kalınlık", "Miktar", "mm", "mm", "μm", "kg" };
            List<string> FA2 = new List<string>() { "F.Metraj", "F.Kalınlık", "F.En", "Miktar", "mm", "μm", "mm", "kg" };
            List<string> FM1 = new List<string>() { "F.İç Çap", "F.Dış Çap", "F.Kalınlık", "Metraj", "mm", "mm", "mm", "m" };
            List<string> FM2 = new List<string>() { "F.Miktar", "F.Kalınlık", "F.En", "Metraj", "kg", "μm", "mm", "m" };
            List<string> IU = new List<string>() {"Dalga Boyu", "Dalga Yüksekliği","IU", "mm" , "mm" ,""};

            calculators.Add("ME1", new Tuple<List<string>, Func<double, double, double, double, double, double>, double>(ME1, Methods.ME1, dens));
            calculators.Add("ME2", new Tuple<List<string>, Func<double, double, double, double, double, double>, double>(ME2, Methods.ME2, dens));
            calculators.Add("DI1", new Tuple<List<string>, Func<double, double, double, double, double, double>, double>(DI1, Methods.OD1, dens));
            calculators.Add("DI2", new Tuple<List<string>, Func<double, double, double, double, double, double>,double>(DI2, Methods.OD2, dens));
            calculators.Add("MI1", new Tuple<List<string>, Func<double, double, double, double, double, double>, double>(MI1, Methods.MI1, dens));
            calculators.Add("MI2", new Tuple<List<string>, Func<double, double, double, double, double, double>, double>(MI2, Methods.MI2, dens));
            calculators.Add("IC1", new Tuple<List<string>, Func<double, double, double, double, double, double>, double>(IC1, Methods.ID1, dens));
            calculators.Add("IC2", new Tuple<List<string>, Func<double, double, double, double, double, double>, double>(IC2, Methods.ID2, dens));
            calculators.Add("KA1", new Tuple<List<string>, Func<double, double, double, double, double, double>, double>(KA1, Methods.KA1, dens));
            calculators.Add("KA2", new Tuple<List<string>, Func<double, double, double, double, double, double>, double>(KA2, Methods.KA2, dens));
            calculators.Add("BO1", new Tuple<List<string>, Func<double, double, double, double, double, double>, double>(BO1, Methods.BO1, dens));
            calculators.Add("BO2", new Tuple<List<string>, Func<double, double, double, double, double, double>, double>(BO2, Methods.BO2, dens));

            calculators.Add("FA1", new Tuple<List<string>, Func<double, double, double, double, double, double>, double>(FA1, Methods.FA1, dens));
            calculators.Add("FA2", new Tuple<List<string>, Func<double, double, double, double, double, double>, double>(FA2, Methods.FA2, dens));
            calculators.Add("FM1", new Tuple<List<string>, Func<double, double, double, double, double, double>, double>(FM1, Methods.FM1, dens));
            calculators.Add("FM2", new Tuple<List<string>, Func<double, double, double, double, double, double>, double>(FM2, Methods.FM2, dens));
            calculators.Add("IU", new Tuple<List<string>, Func<double, double, double, double, double, double>, double>(IU, Methods.IU, dens));
        }


        private async void CMS_Clicked(object sender, EventArgs args)
        {

            string buttontext = (sender as Button).Text;
            string name = (sender as Button).ClassId;
            Tuple<List<string>, Func<double, double, double, double, double, double>, double> selected = calculators[name];
            await Navigation.PushAsync(new CMS(den,selected,name));
        }

        private async void MP_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MecProp());
        }
    }
}