using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CP1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DiamTor : ContentPage
    {
        private SQLiteConnection _sqliteconnection2;
        string thick;
        double width;

        Dictionary<string, string> allproperties1 = new Dictionary<string, string>();
        //ObservableCollection<Alloy> alloycollection;
        List<Diator> Tolerances = new List<Diator>();

        public DiamTor()
        {
            InitializeComponent();
            GetToleranceList();
        }

        private async void GetToleranceList()
        {
            _sqliteconnection2 = await DependencyService.Get<ISQLite>().GetConnection2();
            var thicklist = _sqliteconnection2.Query<Diator>("Select distinct Thick From BoyutTor").ToList();
            KalSec.ItemsSource = thicklist;
        }

        private async void GetSelectedRow(string SelectedThick)
        {
            _sqliteconnection2 = await DependencyService.Get<ISQLite>().GetConnection2();
            var rowlist1 = _sqliteconnection2.Query<Diator>("select * From BoyutTor Where Thick = ?", SelectedThick).ToList();
            Row1.ItemsSource = rowlist1;
        }

        private async void DTS_Clicked(object sender, EventArgs e)
        {
            width = double.Parse(NV(En.Text));
                       
            if (width != 0)
            {
                
                if (width < 101)
                {
                    TMin.Text = allproperties1["En0K"];
                    TMax.Text = allproperties1["En100K"];
                    WMin.Text = allproperties1["En0G"];
                    WMax.Text = allproperties1["En100G"];
                    LMin.Text = allproperties1["En0U"];
                    LMax.Text = allproperties1["En100U"];
                }
                else if (width < 301)
                {
                    TMin.Text = allproperties1["En101K"];
                    TMax.Text = allproperties1["En300K"];
                    WMin.Text = allproperties1["En101G"];
                    WMax.Text = allproperties1["En300G"];
                    LMin.Text = allproperties1["En101U"];
                    LMax.Text = allproperties1["En300U"];
                }

                else if (width < 501)
                {
                    TMin.Text = allproperties1["En301K"];
                    TMax.Text = allproperties1["En500K"];
                    WMin.Text = allproperties1["En301G"];
                    WMax.Text = allproperties1["En500G"];
                    LMin.Text = allproperties1["En301U"];
                    LMax.Text = allproperties1["En500U"];
                }

                else if (width < 1001)
                {
                    TMin.Text = allproperties1["En501K"];
                    TMax.Text = allproperties1["En1000K"];
                    WMin.Text = allproperties1["En501G"];
                    WMax.Text = allproperties1["En1000G"];
                    LMin.Text = allproperties1["En501U"];
                    LMax.Text = allproperties1["En1000U"];
                }


                else if (width < 1251)
                {
                    TMin.Text = allproperties1["En1001K"];
                    TMax.Text = allproperties1["En1250K"];
                    WMin.Text = allproperties1["En1001G"];
                    WMax.Text = allproperties1["En1250G"];
                    LMin.Text = allproperties1["En1001U"];
                    LMax.Text = allproperties1["En1250U"];
                }
                else if (width <= 1600)
                {
                    TMin.Text = allproperties1["En1251K"];
                    TMax.Text = allproperties1["En1600K"];
                    WMin.Text = allproperties1["En1251G"];
                    WMax.Text = allproperties1["En1600G"];
                    LMin.Text = allproperties1["En1251U"];
                    LMax.Text = allproperties1["En1600U"];
                }
                else
                {
                    await DisplayAlert("Uyarı", "Lütfen 1600mm'den Daha Küçük Bir En Giriniz", "OK");
                }
            }
            else
            {
                await DisplayAlert("Uyarı", "Lütfen Bir En Giriniz", "OK");
            }
        }

        private void ThiknessChanged2(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            var ThickRange = (Diator)picker.SelectedItem;
            thick = ThickRange.Thick.ToString();

            GetSelectedRow(thick);

            var alllist = (Diator)Row1.ItemsSource[0];

            //Kalınlık
            allproperties1.Add("En0K", alllist.En0K.ToString());
            allproperties1.Add("En100K", alllist.En100K.ToString());
            allproperties1.Add("En101K", alllist.En101K.ToString());
            allproperties1.Add("En300K", alllist.En300K.ToString());
            allproperties1.Add("En301K", alllist.En301K.ToString());
            allproperties1.Add("En500K", alllist.En500K.ToString());
            allproperties1.Add("En501K", alllist.En501K.ToString());
            allproperties1.Add("En1000K", alllist.En1000K.ToString());
            allproperties1.Add("En1001K", alllist.En1001K.ToString());
            allproperties1.Add("En1250K", alllist.En1250K.ToString());
            allproperties1.Add("En1251K", alllist.En1251K.ToString());
            allproperties1.Add("En1600K", alllist.En1600K.ToString());

            //Genişlik
            allproperties1.Add("En0G", alllist.En0G.ToString());
            allproperties1.Add("En100G", alllist.En100G.ToString());
            allproperties1.Add("En101G", alllist.En101G.ToString());
            allproperties1.Add("En300G", alllist.En300G.ToString());
            allproperties1.Add("En301G", alllist.En301G.ToString());
            allproperties1.Add("En500G", alllist.En500G.ToString());
            allproperties1.Add("En501G", alllist.En501G.ToString());
            allproperties1.Add("En1000G", alllist.En1000G.ToString());
            allproperties1.Add("En1001G", alllist.En1001G.ToString());
            allproperties1.Add("En1250G", alllist.En1250G.ToString());
            allproperties1.Add("En1251G", alllist.En1251G.ToString());
            allproperties1.Add("En1600G", alllist.En1600G.ToString());

            //Boy 
            allproperties1.Add("En0U", alllist.En0U.ToString());
            allproperties1.Add("En100U", alllist.En100U.ToString());
            allproperties1.Add("En101U", alllist.En101U.ToString());
            allproperties1.Add("En300U", alllist.En300U.ToString());
            allproperties1.Add("En301U", alllist.En301U.ToString());
            allproperties1.Add("En500U", alllist.En500U.ToString());
            allproperties1.Add("En501U", alllist.En501U.ToString());
            allproperties1.Add("En1000U", alllist.En1000U.ToString());
            allproperties1.Add("En1001U", alllist.En1001U.ToString());
            allproperties1.Add("En1250U", alllist.En1250U.ToString());
            allproperties1.Add("En1251U", alllist.En1251U.ToString());
            allproperties1.Add("En1600U", alllist.En1600U.ToString());

        }

        private async void Tchanged(object sender, TextChangedEventArgs e)
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
        public string NV(string check)
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