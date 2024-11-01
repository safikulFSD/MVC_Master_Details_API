using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Evidence_api01_witAthentication.Models.ViewModel
{
    public class MedicineViewModel
    {
        public int MedicineId { get; set; }
        [Required, StringLength(100)]
        public string MedicineName { get; set; }
        [Required, StringLength(100)]
        public string CompanyName { get; set; }
        [Required, Column(TypeName = "date")]
        public DateTime ProductionDate { get; set; }
        [Required, Column(TypeName = "date")]
        public DateTime ExpireDate { get; set; }
        [Required, Column(TypeName = "money")]
        public decimal Price { get; set; }
        public bool Onsale { get; set; }
        public string Picture { get; set; }

        public List<SpecInputModel> Specs { get; set; } = new List<SpecInputModel>();
    }
}