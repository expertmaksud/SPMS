namespace ESLab.SPMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateStockDensity : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Stocks", "Density", c => c.Single());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stocks", "Density", c => c.Single(nullable: false));
        }
    }
}
