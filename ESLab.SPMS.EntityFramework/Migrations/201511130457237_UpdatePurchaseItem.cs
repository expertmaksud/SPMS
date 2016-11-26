namespace ESLab.SPMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePurchaseItem : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PurchaseItems", "RawMaterialId", "dbo.RawMaterials");
            DropIndex("dbo.PurchaseItems", new[] { "RawMaterialId" });
            AddColumn("dbo.PurchaseItems", "ProductType", c => c.Int(nullable: false));
            AddColumn("dbo.PurchaseItems", "FinishProductId", c => c.Int());
            AlterColumn("dbo.PurchaseItems", "RawMaterialId", c => c.Int());
            CreateIndex("dbo.RawMaterials", "ProductName", unique: true);
            CreateIndex("dbo.PurchaseItems", "RawMaterialId");
            CreateIndex("dbo.PurchaseItems", "FinishProductId");
            AddForeignKey("dbo.PurchaseItems", "FinishProductId", "dbo.FinishProducts", "Id");
            AddForeignKey("dbo.PurchaseItems", "RawMaterialId", "dbo.RawMaterials", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseItems", "RawMaterialId", "dbo.RawMaterials");
            DropForeignKey("dbo.PurchaseItems", "FinishProductId", "dbo.FinishProducts");
            DropIndex("dbo.PurchaseItems", new[] { "FinishProductId" });
            DropIndex("dbo.PurchaseItems", new[] { "RawMaterialId" });
            DropIndex("dbo.RawMaterials", new[] { "ProductName" });
            AlterColumn("dbo.PurchaseItems", "RawMaterialId", c => c.Int(nullable: false));
            DropColumn("dbo.PurchaseItems", "FinishProductId");
            DropColumn("dbo.PurchaseItems", "ProductType");
            CreateIndex("dbo.PurchaseItems", "RawMaterialId");
            AddForeignKey("dbo.PurchaseItems", "RawMaterialId", "dbo.RawMaterials", "Id", cascadeDelete: false);
        }
    }
}
