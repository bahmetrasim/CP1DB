
using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace CP1
{
    [Table ("Alloy")]
    public class Alloy
    {

        [PrimaryKey]
        public int  AlloyID {get; set;}

        public string AlloyName{get; set;}

        public string Temper {get; set;}

        public string Thickness {get; set;}

        public int Tensile_Min {get; set;}

        public int Tensile_Max {get; set;}

        public int Yield_Min {get; set;}

        public int Yield_Max {get; set;}

        public int Elongation_Min {get; set;}

        public string Bend_90 {get; set;}

        public string Bend_180 {get; set;}

        public int Hardness {get; set;}

    }
}
