using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Evidence_api01_witAthentication.Models
{
    public class Spec
    {
        public int SpecId { get; set; }
        public string SpecName { get; set; }
        public string Value { get; set; }
        [ForeignKey("Medicine")]
        public int MedicineId { get; set; }

        //nav
        public virtual Medicine Medicine { get; set; }
    }
}