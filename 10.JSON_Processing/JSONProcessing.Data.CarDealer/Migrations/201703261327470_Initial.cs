namespace JSONProcessing.Data.CarDealer.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                {
                    CarId = c.Int(nullable: false, identity: true),
                    Make = c.String(maxLength: 200),
                    Model = c.String(maxLength: 200),
                    TravelledDistance = c.Long(nullable: false),
                })
                .PrimaryKey(t => t.CarId);

            CreateTable(
                "dbo.Parts",
                c => new
                {
                    PartId = c.Int(nullable: false, identity: true),
                    Name = c.String(maxLength: 300),
                    Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Quantity = c.Int(nullable: false),
                    SupplierId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.PartId)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.SupplierId);

            CreateTable(
                "dbo.Suppliers",
                c => new
                {
                    SupplierId = c.Int(nullable: false, identity: true),
                    Name = c.String(maxLength: 300),
                    IsImporter = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.SupplierId);

            CreateTable(
                "dbo.Customers",
                c => new
                {
                    CustomerId = c.Int(nullable: false, identity: true),
                    Name = c.String(maxLength: 300),
                    BirthDate = c.DateTime(nullable: false),
                    IsYoungDriver = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.CustomerId);

            CreateTable(
                "dbo.Sales",
                c => new
                {
                    SaleId = c.Int(nullable: false, identity: true),
                    Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    CarId = c.Int(nullable: false),
                    CustomerId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.SaleId)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CarId)
                .Index(t => t.CustomerId);

            CreateTable(
                "dbo.PartCars",
                c => new
                {
                    PartId = c.Int(nullable: false),
                    CarId = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.PartId, t.CarId })
                .ForeignKey("dbo.Cars", t => t.PartId, cascadeDelete: true)
                .ForeignKey("dbo.Parts", t => t.CarId, cascadeDelete: true)
                .Index(t => t.PartId)
                .Index(t => t.CarId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Sales", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Sales", "CarId", "dbo.Cars");
            DropForeignKey("dbo.PartCars", "CarId", "dbo.Parts");
            DropForeignKey("dbo.PartCars", "PartId", "dbo.Cars");
            DropForeignKey("dbo.Parts", "SupplierId", "dbo.Suppliers");
            DropIndex("dbo.PartCars", new[] { "CarId" });
            DropIndex("dbo.PartCars", new[] { "PartId" });
            DropIndex("dbo.Sales", new[] { "CustomerId" });
            DropIndex("dbo.Sales", new[] { "CarId" });
            DropIndex("dbo.Parts", new[] { "SupplierId" });
            DropTable("dbo.PartCars");
            DropTable("dbo.Sales");
            DropTable("dbo.Customers");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Parts");
            DropTable("dbo.Cars");
        }
    }
}
