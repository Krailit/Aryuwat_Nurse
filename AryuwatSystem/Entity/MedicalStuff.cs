using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class MedicalStuff
    {
        public string VN { get; set; }
        public string MS_Code { get; set; }
        public string ListOrder { get; set; }
        
        public string Position_ID { get; set; }
        public string EmployeeId { get; set; }
        public string FullNameCustomer { get; set; }
        public string SectionStuff { get; set; }
        
        public DateTime? Com_Date { get; set; }
        public double Com_Bath { get; set; }
        public string MergStatus { get; set; }//เก็บ code ที่รวมกัน
        public string UseTransId { get; set; }
        

    }
}
