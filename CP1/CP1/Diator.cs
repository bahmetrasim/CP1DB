
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

        public string En0K{ get; set;}

        public string En100K { get; set;}

        public string En101K { get; set;}

        public string En300K { get; set;}

        public string En301K { get; set;}

        public string En500K { get; set;}

        public string En501K { get; set;}

        public string En1000K { get; set;}

        public string En1001K { get; set;}

        public string En1250K { get; set;}

        public string En1251K { get; set;}

        public string En1600K { get; set; }

        public string En0G { get; set; }

        public string En100G { get; set; }

        public string En101G { get; set; }

        public string En300G { get; set; }
        
        public string En301G { get; set; }

        public string En500G { get; set; }

        public string En501G { get; set; }

        public string En1000G { get; set; }

        public string En1001G { get; set; }

        public string En1250G { get; set; }

        public string En1251G { get; set; }

        public string En1600G { get; set; }

        public string En0U { get; set; }

        public string En100U { get; set; }

        public string En101U { get; set; }

        public string En300U { get; set; }

        public string En301U { get; set; }

        public string En500U { get; set; }

        public string En501U { get; set; }

        public string En1000U { get; set; }

        public string En1001U { get; set; }

        public string En1250U { get; set; }

        public string En1251U { get; set; }

        public string En1600U { get; set; }

    }
}
