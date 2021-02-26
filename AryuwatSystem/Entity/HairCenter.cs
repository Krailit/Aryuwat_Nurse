using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class HairCenter
    {
        public int? ID { get; set; }
        public string HairTransplantation { get; set; }
        public string HairReform { get; set; }
        public string HairOther { get; set; }
        public string CN { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateBy { get; set; }
    }
}
