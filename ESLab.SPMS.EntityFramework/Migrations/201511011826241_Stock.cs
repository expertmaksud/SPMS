namespace ESLab.SPMS.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Stock : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        WarehouseId = c.Int(nullable: false),
                        PurchaseItemId = c.Long(nullable: false),
                        ReceiveQuantity = c.Single(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Density = c.Single(nullable: false),
                        StockType = c.Int(nullable: false),
                        ProductType = c.Int(nullable: false),
                        BatchNumber = c.String(maxLength: 100),
                        ReceiveDate = c.DateTime(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Stock_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PurchaseItems", t => t.PurchaseItemId, cascadeDelete: true)
                .ForeignKey("dbo.Warehouses", t => t.WarehouseId, cascadeDelete: true)
                .Index(t => t.WarehouseId)
                .Index(t => t.PurchaseItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stocks", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.Stocks", "PurchaseItemId", "dbo.PurchaseItems");
            DropIndex("dbo.Stocks", new[] { "PurchaseItemId" });
            DropIndex("dbo.Stocks", new[] { "WarehouseId" });
            DropTable("dbo.Stocks",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Stock_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
