namespace JSONProcessing.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                {
                    CategoryId = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 500),
                })
                .PrimaryKey(t => t.CategoryId);

            CreateTable(
                "dbo.Products",
                c => new
                {
                    ProductId = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 500),
                    Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    BuyerId = c.Int(),
                    SellerId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Users", t => t.BuyerId)
                .ForeignKey("dbo.Users", t => t.SellerId, cascadeDelete: true)
                .Index(t => t.BuyerId)
                .Index(t => t.SellerId);

            CreateTable(
                "dbo.Users",
                c => new
                {
                    UserId = c.Int(nullable: false, identity: true),
                    FirstName = c.String(maxLength: 100),
                    LastName = c.String(nullable: false, maxLength: 155),
                    Age = c.Int(),
                })
                .PrimaryKey(t => t.UserId);

            CreateTable(
                "dbo.UserFirends",
                c => new
                {
                    UserId = c.Int(nullable: false),
                    FriendId = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.UserId, t.FriendId })
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Users", t => t.FriendId)
                .Index(t => t.UserId)
                .Index(t => t.FriendId);

            CreateTable(
                "dbo.CategoryProducts",
                c => new
                {
                    CategoryId = c.Int(nullable: false),
                    ProductId = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.CategoryId, t.ProductId })
                .ForeignKey("dbo.Products", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.ProductId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Products", "SellerId", "dbo.Users");
            DropForeignKey("dbo.CategoryProducts", "ProductId", "dbo.Categories");
            DropForeignKey("dbo.CategoryProducts", "CategoryId", "dbo.Products");
            DropForeignKey("dbo.Products", "BuyerId", "dbo.Users");
            DropForeignKey("dbo.UserFirends", "FriendId", "dbo.Users");
            DropForeignKey("dbo.UserFirends", "UserId", "dbo.Users");
            DropIndex("dbo.CategoryProducts", new[] { "ProductId" });
            DropIndex("dbo.CategoryProducts", new[] { "CategoryId" });
            DropIndex("dbo.UserFirends", new[] { "FriendId" });
            DropIndex("dbo.UserFirends", new[] { "UserId" });
            DropIndex("dbo.Products", new[] { "SellerId" });
            DropIndex("dbo.Products", new[] { "BuyerId" });
            DropTable("dbo.CategoryProducts");
            DropTable("dbo.UserFirends");
            DropTable("dbo.Users");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
