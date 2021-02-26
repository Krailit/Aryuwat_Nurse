using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
   public class MedicalOrderDoc
    {
       public string Id { get; set; }
       public string UseTransId { get; set; }
       public string QueryType { get; set; }
       
       public string FileName { get; set; }
       public string Detail { get; set; }
       public string VN { get; set; }
       public string Sono { get; set; }
       public string CN { get; set; }
       public string FilePath { get; set; }
       public DateTime DateScan { get; set; }
       public string ENDoctor { get; set; }
       public string ENSave { get; set; }
       
    }
}
