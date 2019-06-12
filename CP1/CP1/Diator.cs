
using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace CP1
{
    [Table ("Diator")]
    public class Diator
    {

        [PrimaryKey]
        public string Thick{ get; set;}

        public int En0K{ get; set;}

        public int En100K { get; set;}

        public int En101K { get; set;}

        public int En300K { get; set;}

        public int En301K { get; set;}

        public int En500K { get; set;}

        public int En501K { get; set;}

        public int En1000K { get; set;}

        public int En1001K { get; set;}

        public int En1250K { get; set;}

        public int En1251K { get; set;}

        public int En1600K { get; set; }

        public int En0G { get; set; }

        public int En100G { get; set; }

        public int En101G { get; set; }

        public int En300G { get; set; }

        public int En301G { get; set; }

        public int En500G { get; set; }

        public int En501G { get; set; }

        public int En1000G { get; set; }

        public int En1001G { get; set; }

        public int En1250G { get; set; }

        public int En1251G { get; set; }

        public int En1600G { get; set; }

        public int En0U { get; set; }

        public int En100U { get; set; }

        public int En101U { get; set; }

        public int En300U { get; set; }

        public int En301U { get; set; }

        public int En500U { get; set; }

        public int En501U { get; set; }

        public int En1000U { get; set; }

        public int En1001U { get; set; }

        public int En1250U { get; set; }

        public int En1251U { get; set; }

        public int En1600U { get; set; }

    }
}
