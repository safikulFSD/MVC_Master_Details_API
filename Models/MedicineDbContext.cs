using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Evidence_api01_witAthentication.Models
{
    public class MedicineDbContext : DbContext
    {
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Spec> Specs { get; set; }
    }
}