namespace ESLab.SPMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRawMaterialProductUnit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductUnits", "UnitToKg", c => c.Single(nullable: false));
            DropColumn("dbo.RawMaterials", "Density");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RawMaterials", "Density", c => c.String(maxLength: 10));
            DropColumn("dbo.ProductUnits", "UnitToKg");
        }
    }
}
