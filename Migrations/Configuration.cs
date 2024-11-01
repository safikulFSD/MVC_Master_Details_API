namespace Evidence_api01_witAthentication.Migrations
{
    using Evidence_api01_witAthentication.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Evidence_api01_witAthentication.Models.MedicineDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Evidence_api01_witAthentication.Models.MedicineDbContext context)
        {
            Medicine medicine = new Medicine
            {
                MedicineName="Napa",
                CompanyName="Acme",
                ProductionDate=new DateTime(2023,10,10),
                ExpireDate=new DateTime(2025,10,09),
                Price=50.00M,
                Onsale=true,
                Picture="1.jpg"
            };
            medicine.Specs.Add(new Spec
            {
                SpecName="Syrup",
                Value="100ml" 
            });
            medicine.Specs.Add(new Spec
            {
                SpecName = "Suppository",
                Value = "500ml"
            });
            context.Medicines.Add(medicine);
            context.SaveChanges();
        }
    }
}
