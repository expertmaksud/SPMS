namespace ESLab.SPMS.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class BrandTypeAndRawMaterials : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RawMaterials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RawMaterialTypeId = c.Int(nullable: false),
                        BrandId = c.Int(nullable: false),
                        ProductName = c.String(maxLength: 100),
                        Model = c.String(maxLength: 40),
                        Size = c.String(maxLength: 10),
                        Color = c.String(maxLength: 20),
                        Origin = c.String(maxLength: 20),
                        Density = c.String(maxLength: 10),
                        ProductUnitId = c.Int(nullable: false),
                        ReOrderPoint = c.Int(nullable: false),
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
                    { "DynamicFilter_RawMaterial_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .ForeignKey("dbo.ProductUnits", t => t.ProductUnitId, cascadeDelete: true)
                .ForeignKey("dbo.RawMaterialTypes", t => t.RawMaterialTypeId, cascadeDelete: true)
                .Index(t => t.RawMaterialTypeId)
                .Index(t => t.BrandId)
                .Index(t => t.ProductUnitId);
            
            AddColumn("dbo.Brands", "BrandType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RawMaterials", "RawMaterialTypeId", "dbo.RawMaterialTypes");
            DropForeignKey("dbo.RawMaterials", "ProductUnitId", "dbo.ProductUnits");
            DropForeignKey("dbo.RawMaterials", "BrandId", "dbo.Brands");
            DropIndex("dbo.RawMaterials", new[] { "ProductUnitId" });
            DropIndex("dbo.RawMaterials", new[] { "BrandId" });
            DropIndex("dbo.RawMaterials", new[] { "RawMaterialTypeId" });
            DropColumn("dbo.Brands", "BrandType");
            DropTable("dbo.RawMaterials",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_RawMaterial_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
