using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AryuwatWebApplication.Models
{
    public class MedicalExpireModel
    {
        public int? dataCount { get; set; }
        public DateTime? oneNextChange { get; set; }
        public DateTime? twoNextChange { get; set; }
    }
}