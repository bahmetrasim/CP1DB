//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace CP1
//{
//    class CalculateScrren1
//    {
//        Dictionary<string, Tuple<List<string>, Func<double, double, double, double, double>, double>> calculators = new Dictionary<string, Tuple<List<string>, Func<double, double, double, double, double>, double>>();
//        double Density;

//        public CalculateScrren1(double Den)
//        {
//            Density = Den;
//            List<string> ME1 = new List<string>() { "İç Çap", "Dış Çap", "Kalınlık", "Metraj", "mm", "mm", "mm", "m" };
//            List<string> ME2 = new List<string>() { "Miktar", "En", "Kalınlık", "Metraj", "kg", "mm", "mm", "m" };
//            List<string> OD1 = new List<string>() { "İç Çap", "En", "Miktar", "Dış Çap", "mm", "mm", "kg", "mm" };
//            List<string> OD2 = new List<string>() { "İç Çap", "Metraj", "Kalınlık", "Dış Çap", "mm", "m", "mm", "mm" };
//            List<string> ID1 = new List<string>() { "Miktar", "Dış Çap", "En", "İç Çap", "kg", "mm", "mm", "mm" };
//            List<string> ID2 = new List<string>() { "Metraj", "Dış Çap", "Kalınlık", "İç Çap", "m", "mm", "mm", "mm" };
//            List<string> KA1 = new List<string>() { "Miktar", "Metraj", "En", "Kalınlık", "kg", "m", "mm", "mm" };
//            List<string> KA2 = new List<string>() { "İç Çap", "Dış Çap", "Metraj", "Kalınlık", "mm", "mm", "m", "mm" };
//            List<string> MI1 = new List<string>() { "Metraj", "En", "Kalınlık", "Miktar", "m", "mm", "mm", "kg" };
//            List<string> MI2 = new List<string>() { "İç Çap", "Dış Çap", "En", "Miktar", "mm", "mm", "mm", "kg" };

//            List<string> FA1 = new List<string>() { "F.Dış Çap", "F.İç Çap", "F.Kalınlık", "Miktar", "mm", "mm", "mc", "kg" };
//            List<string> FA2 = new List<string>() { "F.Metraj", "F.Kalınlık", "F.En", "Miktar", "mm", "mc", "mm", "kg" };
//            List<string> FM1 = new List<string>() { "F.İç Çap", "F.Dış Çap", "F.En", "Metraj", "mm", "mm", "mm", "m" };
//            List<string> FM2 = new List<string>() { "F.Miktar", "F.Kalınlık", "F.En", "Metraj", "kg", "mc", "mm", "m" };

//            calculators.Add("ME1", new Tuple<List<string>, Func<double, double, double, double, double>, double>(ME1, Methods.ME1, Den));
//            calculators.Add("ME2", new Tuple<List<string>, Func<double, double, double, double, double>, double>(ME2, Methods.ME2, Den));
//            calculators.Add("OD1", new Tuple<List<string>, Func<double, double, double, double, double>, double>(OD1, Methods.OD1, Den));
//            calculators.Add("OD2", new Tuple<List<string>, Func<double, double, double, double, double>, double>(OD2, Methods.OD2, Den));
//            calculators.Add("MI1", new Tuple<List<string>, Func<double, double, double, double, double>, double>(MI1, Methods.MI1, Den));
//            calculators.Add("MI2", new Tuple<List<string>, Func<double, double, double, double, double>, double>(MI2, Methods.MI2, Den));
//            calculators.Add("ID1", new Tuple<List<string>, Func<double, double, double, double, double>, double>(ID1, Methods.ID1, Den));
//            calculators.Add("ID2", new Tuple<List<string>, Func<double, double, double, double, double>, double>(ID2, Methods.ID2, Den));
//            calculators.Add("KA1", new Tuple<List<string>, Func<double, double, double, double, double>, double>(KA1, Methods.KA1, Den));
//            calculators.Add("KA2", new Tuple<List<string>, Func<double, double, double, double, double>, double>(KA2, Methods.KA2, Den));

//            calculators.Add("FA1", new Tuple<List<string>, Func<double, double, double, double, double>, double>(FA1, Methods.FA1, Den));
//            calculators.Add("FA2", new Tuple<List<string>, Func<double, double, double, double, double>, double>(FA2, Methods.FA2, Den));
//            calculators.Add("FM1", new Tuple<List<string>, Func<double, double, double, double, double>, double>(FM1, Methods.FM1, Den));
//            calculators.Add("FM2", new Tuple<List<string>, Func<double, double, double, double, double>, double>(FM2, Methods.FM2, Den));

//        }
//        private void b_choosecalculator(object sender, EventArgs e)
//        {

//            Button calc = (Button)sender;
//            string formname = calc.Name;
//            var form = forms[formname];

//            form.Controls["TextBox1"].Text = "";
//            form.Controls["TextBox2"].Text = "";
//            form.Controls["TextBox3"].Text = "";
//            form.Controls["result"].Text = "";
//            if (formname == "BO1")
//                form.Controls["TextBox4"].Text = "";
//            else
//                form.Controls["comboBox1"].Text = "";

//            form.ShowDialog();
//        }

//        private void b_choosecoilcalculator(object sender, EventArgs e)
//        {
//            // inline (this works, uncomment and see)
//            // var genericForm = new GenericForm("İç çap", "Dış çap", "Kalınlık", "Metraj", "mm", "mm", "mm", "m", (ID, OD, t) => { return (((Math.PI * (OD * OD - ID * ID)) / (4 * t)) / 1000); });
//            // external
//            //var genericForm = new GenericForm("İç çap", "Dış çap", "Kalınlık", "Metraj", "mm", "mm", "mm", "m", Methods.ME1);
//            Button calc = (Button)sender;
//            Tuple<List<string>, Func<double, double, double, double, double>, double> selected = calculators[calc.Name];
//            var genericForm = new GenericForm(Density, selected);
//            genericForm.ShowDialog();
//        }
//    }
//}
