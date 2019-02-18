using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CP1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CMS : ContentPage

    {
        Func<double, double, double, double, double, double> CalculationMethod;
        Dictionary<string, double> resinlist = new Dictionary<string, double>();
        double Density;
        string page;
        string cov = "";


        public CMS()
        {
            InitializeComponent();
        }

        public CMS(double Den, Tuple<List<string>, Func<double, double, double, double, double, double>, double> calculator, string page)
        {
            InitializeComponent();
            resinlist.Add("PVDF", 275);
            resinlist.Add("PE", 410);
            resinlist.Add("PE-PRIMER", 385);
            resinlist.Add("HDPE", 385);
            resinlist.Add("EPOXY", 275);
            resinlist.Add("EPOXY-PE", 390);
            resinlist.Add("WRINKLE", 380);
            resinlist.Add("PUR-PA", 395);
            resinlist.Add("PU-BASE", 375);
            resinlist.Add("PA-CLEAR", 360);
            this.page = page;

            foreach (string ChooseCov in resinlist.Keys)
            {
                Rezine.Items.Add(ChooseCov);
            }

            if (page != "BO1" && page != "BO2" && page !="IU")
            {

                LabelParam1.Text = calculator.Item1[0];
                LabelParam2.Text = calculator.Item1[1];
                LabelParam3.Text = calculator.Item1[2];
                Labelresult.Text = calculator.Item1[3];

                UnitParam1.Text = calculator.Item1[4];
                UnitParam2.Text = calculator.Item1[5];
                UnitParam3.Text = calculator.Item1[6];
                Unitresult.Text = calculator.Item1[7];

                UnitParam4.IsVisible = false;
                LabelParam4.IsVisible = false;
                Entryparam4.IsVisible = false;
                Rezine.IsVisible = false;
                LabelParam5.IsVisible = false;
                UnitParam5.IsVisible = false;

            }
            else if (page == "BO1")
            {
                LabelParam1.Text = calculator.Item1[0];
                LabelParam2.Text = calculator.Item1[1];
                LabelParam3.Text = calculator.Item1[2];
                LabelParam4.Text = calculator.Item1[3];
                Labelresult.Text = calculator.Item1[4];

                UnitParam1.Text = calculator.Item1[5];
                UnitParam2.Text = calculator.Item1[6];
                UnitParam3.Text = calculator.Item1[7];
                UnitParam4.Text = calculator.Item1[8];
                Unitresult.Text = calculator.Item1[9];

                Rezine.IsVisible = false;
                LabelParam5.IsVisible = false;
                UnitParam5.IsVisible = false;

            }

            else if (page == "BO2")
            {
                LabelParam1.Text = calculator.Item1[0];
                LabelParam2.Text = calculator.Item1[1];
                LabelParam3.Text = calculator.Item1[2];
                LabelParam5.Text = calculator.Item1[3];
                Labelresult.Text = calculator.Item1[4];

                UnitParam1.Text = calculator.Item1[5];
                UnitParam2.Text = calculator.Item1[6];
                UnitParam3.Text = calculator.Item1[7];
                UnitParam5.Text = calculator.Item1[8];
                Unitresult.Text = calculator.Item1[9];

                UnitParam4.IsVisible = false;
                LabelParam4.IsVisible = false;
                Entryparam4.IsVisible = false;

            }
            else if (page =="IU")
            {
                LabelParam1.Text = calculator.Item1[0];
                LabelParam2.Text = calculator.Item1[1];
                Labelresult.Text = calculator.Item1[2];

                UnitParam1.Text = calculator.Item1[3];
                UnitParam2.Text = calculator.Item1[4];
                Unitresult.Text = calculator.Item1[5];


                UnitParam3.IsVisible = false;
                LabelParam3.IsVisible = false;
                Entryparam3.IsVisible = false;
                UnitParam4.IsVisible = false;
                LabelParam4.IsVisible = false;
                Entryparam4.IsVisible = false;
                Rezine.IsVisible = false;
                LabelParam5.IsVisible = false;
                UnitParam5.IsVisible = false;
            }

            Density = Den;
            this.CalculationMethod = calculator.Item2;

        }

        private void ResinSelected(object sender, EventArgs e)
        {
            var rezin = (Picker)sender;

            if (rezin.SelectedIndex == -1)
            {
                cov = "PE";
            }
            else
            {
                cov = rezin.Items[rezin.SelectedIndex];
            }
        }


        private async void Calculate_Clicked(object sender, EventArgs e)
        {
            if (page != "BO1" && page != "BO2" && page!="IU")
            {
                if (Entryparam1.Text == "" || Entryparam2.Text == "" || Entryparam3.Text == "")
                {
                    await DisplayAlert("Uyarı", "Tüm Değerleri Giriniz", "OK");
                }
                else
                {
                    double veri1 = double.Parse(NV(Entryparam1.Text), NumberStyles.Any, CultureInfo.InvariantCulture),
                        veri2 = double.Parse(NV(Entryparam2.Text), NumberStyles.Any, CultureInfo.InvariantCulture),
                        veri3 = double.Parse(NV(Entryparam3.Text), NumberStyles.Any, CultureInfo.InvariantCulture);

                    double result = Math.Round(CalculationMethod.Invoke(Density, veri1, veri2, veri3, 1), 2);

                    this.RESULT.Text = result.ToString();
                }
            }
            else if (page == "BO1")
            {
                if (Entryparam1.Text == "" || Entryparam2.Text == "" || Entryparam3.Text == "" || Entryparam4.Text == "")
                {
                    await DisplayAlert("Uyarı", "Tüm Değerleri Giriniz", "OK");
                }
                else
                {
                    double veri1 = double.Parse(NV(Entryparam1.Text), NumberStyles.Any, CultureInfo.InvariantCulture),
                        veri2 = double.Parse(NV(Entryparam2.Text), NumberStyles.Any, CultureInfo.InvariantCulture),
                        veri3 = double.Parse(NV(Entryparam3.Text), NumberStyles.Any, CultureInfo.InvariantCulture),
                    veri4 = double.Parse(NV(Entryparam4.Text), NumberStyles.Any, CultureInfo.InvariantCulture);

                    double result = Math.Round(CalculationMethod.Invoke(Density, veri1, veri2, veri3, veri4), 2);

                    this.RESULT.Text = result.ToString();
                }

            }
            else if (page == "BO2")
            {

                if (Entryparam1.Text == "" || Entryparam2.Text == "" || Entryparam3.Text == "")
                {
                    await DisplayAlert("Uyarı", "Tüm Değerleri Giriniz", "OK");
                }

                else if (cov == "")
                {
                    await DisplayAlert("Uyarı", "Boya Türünü Seçiniz", "OK");
                }
                else
                {
                    double  veri1 = double.Parse(NV(Entryparam1.Text), NumberStyles.Any, CultureInfo.InvariantCulture),
                            veri2 = double.Parse(NV(Entryparam2.Text), NumberStyles.Any, CultureInfo.InvariantCulture),
                            veri3 = double.Parse(NV(Entryparam3.Text), NumberStyles.Any, CultureInfo.InvariantCulture),
                    veri4 = resinlist[cov];

                    double result = Math.Round(CalculationMethod.Invoke(Density, veri1, veri2, veri3, veri4), 2);

                    this.RESULT.Text = result.ToString();
                }
            }
            else if (page == "IU")
            {
                if (Entryparam1.Text == "" || Entryparam2.Text == "")
                {
                    await DisplayAlert("Uyarı", "Tüm Değerleri Giriniz", "OK");
                }
                else
                {
                    double veri1 = double.Parse(NV(Entryparam1.Text), NumberStyles.Any, CultureInfo.InvariantCulture),
                            veri2 = double.Parse(NV(Entryparam2.Text), NumberStyles.Any, CultureInfo.InvariantCulture);
                            
                    double result = Math.Round(CalculationMethod.Invoke(Density, veri1, veri2, 1, 1), 2);

                    this.RESULT.Text = result.ToString();
                }
            }
        }


        private async void Startentry(object sender, TextChangedEventArgs e)
        {
            var value = (sender as Entry).Text;
            var ıd = (sender as Entry).ClassId;
            if (!value.All(c => char.IsDigit(c) || c == '.' || c == ','))
            {
                await DisplayAlert("Uyarı", "Sadece Rakamları Kullanınız", "OK");
                value = new string(value.ToCharArray().Where(x => char.IsDigit(x) || x == '.' || x == ',').ToArray());
                //imleci harfleri sildikten sonra en başa atıyordu imleç sonda kalsın diye yazdım. Başka yolu var mı bilmiyorum

            }
        }
        //Nokta Virgül dönüştürmesi
        public string NV (string check)
        {
            char[] array = check.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                char conv = array[i];
                if (conv == ',')
                {
                    array[i] = '.';
                }
            }
            check = new string(array);
            return check;
        }
    }
}