namespace ESLab.SPMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateStock : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stocks", "TotalQuantity", c => c.Single(nullable: false));
            AddColumn("dbo.Stocks", "ReceivedType", c => c.Int(nullable: false));
            DropColumn("dbo.Stocks", "UnitPrice");
            DropColumn("dbo.Stocks", "ProductType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stocks", "ProductType", c => c.Int(nullable: false));
            AddColumn("dbo.Stocks", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Stocks", "ReceivedType");
            DropColumn("dbo.Stocks", "TotalQuantity");
        }
    }
}
