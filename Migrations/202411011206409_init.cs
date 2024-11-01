namespace Evidence_api01_witAthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        MedicineId = c.Int(nullable: false, identity: true),
                        MedicineName = c.String(nullable: false, maxLength: 100),
                        CompanyName = c.String(nullable: false, maxLength: 100),
                        ProductionDate = c.DateTime(nullable: false, storeType: "date"),
                        ExpireDate = c.DateTime(nullable: false, storeType: "date"),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                        Onsale = c.Boolean(nullable: false),
                        Picture = c.String(),
                    })
                .PrimaryKey(t => t.MedicineId);
            
            CreateTable(
                "dbo.Specs",
                c => new
                    {
                        SpecId = c.Int(nullable: false, identity: true),
                        SpecName = c.String(),
                        Value = c.String(),
                        MedicineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SpecId)
                .ForeignKey("dbo.Medicines", t => t.MedicineId, cascadeDelete: true)
                .Index(t => t.MedicineId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Specs", "MedicineId", "dbo.Medicines");
            DropIndex("dbo.Specs", new[] { "MedicineId" });
            DropTable("dbo.Specs");
            DropTable("dbo.Medicines");
        }
    }
}
