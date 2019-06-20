using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.Collections.ObjectModel;

namespace CP1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MecProp : ContentPage
    {
        private SQLiteConnection _sqliteconnection;
        string alloy1;
        string temper1;
        string thick1;

        string alloy2;
        string temper2;
        string thick2;

        Dictionary<string, string> allproperties1 = new Dictionary<string, string>();
        Dictionary<string, string> allproperties2 = new Dictionary<string, string>();
        //ObservableCollection<Alloy> alloycollection;
        List<Alloy> alloys = new List<Alloy>();
        public  MecProp()
        {
            InitializeComponent();
            show2.IsVisible = false;
            GetAlloyList();
            
            
        }

        private void MPS_Clicked(object sender, EventArgs e)
        {
            TMax.Text = allproperties1["TensileMax"];
            TMin.Text = allproperties1["TensileMin"];
            YMax.Text = allproperties1["YieldMax"];
            YMin.Text = allproperties1["YieldMin"];
            B180.Text = allproperties1["Bend180"];
            B90.Text = allproperties1["Bend90"];
            EMax.Text = "";
            EMin.Text = allproperties1["ElogMin"];
            Hard.Text = allproperties1["Hardness"];
        }
        private void MPC_Clicked(object sender, EventArgs e)
        {
            if (show2.IsVisible == false)
            {
                show2.IsVisible = true;
            }
            else
            {
                TMaxC.Text = allproperties1["TensileMax2"];
                TMinC.Text = allproperties1["TensileMin2"];
                YMaxC.Text = allproperties1["YieldMax2"];
                YMinC.Text = allproperties1["YieldMin2"];
                B180C.Text = allproperties1["Bend1802"];
                B90C.Text = allproperties1["Bend902"];
                EMaxC.Text = "";
                EMinC.Text = allproperties1["ElogMin2"];
                HardC.Text = allproperties1["Hardness2"];

            }
        }
        private void Alloychanged(object sender, EventArgs e)
        {
            
            var picker = (Picker)sender;
            var alloyname = (Alloy)picker.SelectedItem;
            alloy1 = alloyname.AlloyName.ToString();
            GetTemperList(alloy1);
        }
        private void Temperchanged(object sender, EventArgs e)
        {
            
            var picker = (Picker)sender;
            var tempername = (Alloy)picker.SelectedItem;
            temper1 = tempername.Temper.ToString();
            GetThickList(alloy1, temper1);
        }
        private void Thicknesschanged(object sender, EventArgs e)
        {
            
            var picker = (Picker)sender;
            var thick = (Alloy)picker.SelectedItem;
            thick1 = thick.Thickness.ToString();
            GetSelectedRow(alloy1, temper1, thick1);
            var alllist = (Alloy)Row1.ItemsSource[0];

            allproperties1.Add("TensileMax", alllist.Tensile_Max.ToString());
            allproperties1.Add("TensileMin", alllist.Tensile_Min.ToString());
            allproperties1.Add("YieldMax", alllist.Yield_Max.ToString());
            allproperties1.Add("YieldMin", alllist.Yield_Min.ToString());
            allproperties1.Add("ElogMin", alllist.Elongation_Min.ToString());
            allproperties1.Add("Bend180", alllist.Bend_180.ToString());
            allproperties1.Add("Bend90", alllist.Bend_90.ToString());
            allproperties1.Add("Hardness", alllist.Hardness.ToString());

            //GetTensileMax(alloy1, temper1, thick1);
            //GetTensileMin(alloy1, temper1, thick1);
            //GetYieldMax(alloy1, temper1, thick1);
            //GetYieldMin(alloy1, temper1, thick1);
            //GetElogMax(alloy1, temper1, thick1);
            //GetElogMin(alloy1, temper1, thick1);
            //GetBend90(alloy1, temper1, thick1);
            //GetBend180(alloy1, temper1, thick1);
            //GetHard(alloy1, temper1, thick1);
        }
        private void Alloy2changed(object sender, EventArgs e)
        {
           
            var picker = (Picker)sender;
            var alloyname = (Alloy)picker.SelectedItem;
            alloy2 = alloyname.AlloyName.ToString();

            GetTemperList2(alloy2);
        }
        private void Temper2changed(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            var tempername2 = (Alloy)picker.SelectedItem;
            temper2 = tempername2.Temper.ToString();
            GetThickList2(alloy2, temper2);

        }
        private void Thickness2changed(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            var thick = (Alloy)picker.SelectedItem;
            thick2 = thick.Thickness.ToString();
            GetSelectedRow2(alloy2, temper2, thick2);
            var alllist = (Alloy)Row2.ItemsSource[0];

            allproperties1.Add("TensileMax2", alllist.Tensile_Max.ToString());
            allproperties1.Add("TensileMin2", alllist.Tensile_Min.ToString());
            allproperties1.Add("YieldMax2", alllist.Yield_Max.ToString());
            allproperties1.Add("YieldMin2", alllist.Yield_Min.ToString());
            allproperties1.Add("ElogMin2", alllist.Elongation_Min.ToString());
            allproperties1.Add("Bend1802", alllist.Bend_180.ToString());
            allproperties1.Add("Bend902", alllist.Bend_90.ToString());
            allproperties1.Add("Hardness2", alllist.Hardness.ToString());

        }

        private async void GetAlloyList()
        {

            _sqliteconnection = await DependencyService.Get<ISQLite>().GetConnection();
            var alloylist = _sqliteconnection.Query<Alloy>("Select distinct AlloyName From Alloy").ToList();
            alasim.ItemsSource = alloylist;
            alasim2.ItemsSource = alloylist;
        }

        private async void GetTemperList(string SelectedAlloy)
        {
            if(kond.Items.Count !=0 )
            { kond.Items.Clear(); }
            _sqliteconnection = await DependencyService.Get<ISQLite>().GetConnection();
            var temperlist = _sqliteconnection.Query<Alloy>("select distinct Temper From Alloy Where AlloyName = ?", SelectedAlloy).ToList();
            kond.ItemsSource = temperlist;
        }

        private async void GetThickList(string SelectedAlloy, string SelectedTemper)
        {
            if (kalınlık.Items.Count != 0)
            { kalınlık.Items.Clear(); }
            _sqliteconnection = await DependencyService.Get<ISQLite>().GetConnection();
            var thicklist = _sqliteconnection.Query<Alloy>("select Thickness From Alloy Where AlloyName = ? and Temper = ?", SelectedAlloy, SelectedTemper).ToList();
            kalınlık.ItemsSource = thicklist;
        }

        private async void GetTemperList2(string SelectedAlloy)
        {
            if (kond2.Items.Count != 0)
            { kond2.Items.Clear(); }
            _sqliteconnection = await DependencyService.Get<ISQLite>().GetConnection();
            var temperlist2 = _sqliteconnection.Query<Alloy>("select distinct Temper From Alloy Where AlloyName = ?", SelectedAlloy).ToList();
            kond2.ItemsSource = temperlist2;
        }

        private async void GetThickList2(string SelectedAlloy, string SelectedTemper)
        {
            if (kalınlık2.Items.Count != 0)
            { kalınlık2.Items.Clear(); }
            _sqliteconnection = await DependencyService.Get<ISQLite>().GetConnection();
            var thicklist2 = _sqliteconnection.Query<Alloy>("select Thickness From Alloy Where AlloyName = ? and Temper = ?", SelectedAlloy, SelectedTemper).ToList();
            kalınlık2.ItemsSource = thicklist2;
        }

        private async void GetSelectedRow(string SelectedAlloy, string SelectedTemper, string SelectedThick)
        {
            _sqliteconnection = await DependencyService.Get<ISQLite>().GetConnection();
            var rowlist1 = _sqliteconnection.Query<Alloy>("select * From Alloy Where AlloyName = ? and Temper = ? and Thickness = ?", SelectedAlloy, SelectedTemper, SelectedThick).ToList();
            Row1.ItemsSource = rowlist1;
        }

        private async void GetSelectedRow2(string SelectedAlloy, string SelectedTemper, string SelectedThick)
        {
            _sqliteconnection = await DependencyService.Get<ISQLite>().GetConnection();
            var rowlist2 = _sqliteconnection.Query<Alloy>("select * From Alloy Where AlloyName = ? and Temper = ? and Thickness = ?", SelectedAlloy, SelectedTemper, SelectedThick).ToList();
            Row2.ItemsSource = rowlist2;
        }
    }
}