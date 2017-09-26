namespace LocalStore.Migrations
{

    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Products", "Description", s => s.String(defaultValueSql: "'No description'"));
            AlterColumn("Sales","Date", s=>s.String(defaultValue:"GETDATE()"));
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        CreditCardNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        StoreLocationId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.StoreLocations", t => t.StoreLocationId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.CustomerId)
                .Index(t => t.StoreLocationId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Quantity = c.Double(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StoreLocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocationName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            AlterColumn("Sales", "Date", s => s.String(defaultValue: "NULL"));
            DropForeignKey("dbo.Sales", "StoreLocationId", "dbo.StoreLocations");
            DropForeignKey("dbo.Sales", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Sales", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Sales", new[] { "StoreLocationId" });
            DropIndex("dbo.Sales", new[] { "CustomerId" });
            DropIndex("dbo.Sales", new[] { "ProductId" });
            DropTable("dbo.StoreLocations");
            DropTable("dbo.Products");
            DropTable("dbo.Sales");
            DropTable("dbo.Customers");
        }
    }
}
