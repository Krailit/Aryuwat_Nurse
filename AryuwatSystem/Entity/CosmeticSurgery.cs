using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class CosmeticSurgery
    {
        public int? ID { get; set; }
        public string CN { get; set; }
        public string Eye { get; set; }
        public string Nose { get; set; }
        public string Chest { get; set; }
        public string Other { get; set; }
        public string  CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateBy { get; set; }
    }
}
