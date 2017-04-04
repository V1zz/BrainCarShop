namespace CarShopLayer.Migrations
{
    using System.Data.Entity.Migrations;
    
    // ReSharper disable once InconsistentNaming
    public partial class newMOdel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BrandId = c.Guid(nullable: false),
                        Name = c.String(),
                        Code = c.String(),
                        Year = c.Int(nullable: false),
                        ModelTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ModelTypes", t => t.ModelTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Brands", t => t.BrandId)
                .Index(t => t.BrandId)
                .Index(t => t.ModelTypeId);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ModelId = c.Guid(nullable: false),
                        Color = c.String(),
                        ChasisNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Models", t => t.ModelId)
                .Index(t => t.ModelId);
            
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CarId = c.Guid(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 8, scale: 2),
                        CurrencyId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currencies", t => t.CurrencyId, cascadeDelete: true)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .Index(t => t.CarId)
                .Index(t => t.CurrencyId);
            
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Code = c.String(),
                        Glyth = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ModelTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Models", "BrandId", "dbo.Brands");
            DropForeignKey("dbo.Models", "ModelTypeId", "dbo.ModelTypes");
            DropForeignKey("dbo.Cars", "ModelId", "dbo.Models");
            DropForeignKey("dbo.Prices", "CarId", "dbo.Cars");
            DropForeignKey("dbo.Prices", "CurrencyId", "dbo.Currencies");
            DropIndex("dbo.Prices", new[] { "CurrencyId" });
            DropIndex("dbo.Prices", new[] { "CarId" });
            DropIndex("dbo.Cars", new[] { "ModelId" });
            DropIndex("dbo.Models", new[] { "ModelTypeId" });
            DropIndex("dbo.Models", new[] { "BrandId" });
            DropTable("dbo.ModelTypes");
            DropTable("dbo.Currencies");
            DropTable("dbo.Prices");
            DropTable("dbo.Cars");
            DropTable("dbo.Models");
            DropTable("dbo.Brands");
        }
    }
}
