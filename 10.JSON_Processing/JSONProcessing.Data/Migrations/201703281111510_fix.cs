namespace JSONProcessing.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
