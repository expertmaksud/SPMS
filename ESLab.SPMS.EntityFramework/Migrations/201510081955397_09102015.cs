namespace ESLab.SPMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _09102015 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Distributors", "ZoneId", "dbo.Zones");
            DropIndex("dbo.Distributors", new[] { "ZoneId" });
            AlterColumn("dbo.Distributors", "ZoneId", c => c.Int());
            CreateIndex("dbo.Distributors", "ZoneId");
            AddForeignKey("dbo.Distributors", "ZoneId", "dbo.Zones", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Distributors", "ZoneId", "dbo.Zones");
            DropIndex("dbo.Distributors", new[] { "ZoneId" });
            AlterColumn("dbo.Distributors", "ZoneId", c => c.Int(nullable: false));
            CreateIndex("dbo.Distributors", "ZoneId");
            AddForeignKey("dbo.Distributors", "ZoneId", "dbo.Zones", "Id", cascadeDelete: true);
        }
    }
}
