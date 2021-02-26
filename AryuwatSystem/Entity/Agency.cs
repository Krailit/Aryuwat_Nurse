using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Agency
    {
        public bool saveNew { get; set; }

        public string SaveTyp { get; set; }
        public string AgenID { get; set; }
        public string AgenName { get; set; }
        public string AgenAddress { get; set; }
        public string AgenTel { get; set; }
        public string BeUnder { get; set; }
        
        public string AgenDescript { get; set; }
        public string AgenTyp { get; set; }
        public double AgenRate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string ENSave { get; set; }
        public string SupportName { get; set; }
        public string SupportTel { get; set; }
      
        public string AgenMemID { get; set; }
        public string AgenMemPrefix { get; set; }
        public string AgenMemName { get; set; }
        public string AgenMemSurName { get; set; }
        public string AgenMemAddress { get; set; }
        public string AgenMemTel { get; set; }
        public string AgenMemIDCard { get; set; }
        public double AgenMemRate { get; set; }

        public string CN { get; set; }
        public string AgencyEmpTranNote { get; set; }
        public double ComRate { get; set; }

        public int PageNumber;
    }
}
