namespace ESLab.SPMS.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Warehouse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Warehouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WarehouseCode = c.String(maxLength: 20),
                        WarehouseName = c.String(maxLength: 100),
                        WarehouseAddress = c.String(maxLength: 200),
                        WarehousePhone = c.String(maxLength: 30),
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
                    { "DynamicFilter_Warehouse_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.WarehouseCode, unique: true)
                .Index(t => t.WarehouseName, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Warehouses", new[] { "WarehouseName" });
            DropIndex("dbo.Warehouses", new[] { "WarehouseCode" });
            DropTable("dbo.Warehouses",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Warehouse_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
