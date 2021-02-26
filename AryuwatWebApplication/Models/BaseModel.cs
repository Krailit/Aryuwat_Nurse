using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AryuwatWebApplication.Models
{
    public class TableSearchReceive
    {
        public string sort { get; set; }
        public int? page { get; set; }
        public int? per_page { get; set; }
        public string filter1 { get; set; }
        public string filter2 { get; set; }
        public string filter3 { get; set; }
        public string filter4 { get; set; }
        public string filter5 { get; set; }
        public string filter6 { get; set; }
        public string filter7 { get; set; }
        public string filter_fix { get; set; }
    }
    public class TableSearchRespose
    {
        public Nullable<int> total { get; set; }
        public Nullable<int> per_page { get; set; }
        public Nullable<int> current_page { get; set; }
        public Nullable<int> last_page { get; set; }
        public string next_page_url { get; set; }
        public string prev_page_url { get; set; }
        public Nullable<int> from { get; set; }
        public Nullable<int> to { get; set; }
        public object data { get; set; }
    }

}