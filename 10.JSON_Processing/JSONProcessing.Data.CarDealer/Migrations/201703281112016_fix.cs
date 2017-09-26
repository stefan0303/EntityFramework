namespace JSONProcessing.Data.CarDealer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sales", "Discount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sales", "Discount", c => c.Double(nullable: false));
        }
    }
}
