using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
   public class AestheticCenter
    {
        public int?  ID { get; set; }
        public string FacialDesign { get; set; }
        public string FacialTreatment { get; set; }
        public string Laser { get; set; }
        public string AestheticOther { get; set; }
        public string CN { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpDateDate { get; set; }
    }
}
