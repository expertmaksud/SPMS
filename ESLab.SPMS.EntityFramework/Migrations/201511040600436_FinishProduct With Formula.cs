namespace ESLab.SPMS.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class FinishProductWithFormula : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FinishProductFormulas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FinishProductId = c.Int(nullable: false),
                        RawMaterialId = c.Int(nullable: false),
                        Percentage = c.Single(nullable: false),
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
                    { "DynamicFilter_FinishProductFormula_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FinishProducts", t => t.FinishProductId, cascadeDelete: true)
                .ForeignKey("dbo.RawMaterials", t => t.RawMaterialId, cascadeDelete: true)
                .Index(t => t.FinishProductId)
                .Index(t => t.RawMaterialId);
            
            CreateTable(
                "dbo.FinishProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(maxLength: 100),
                        BrandId = c.Int(nullable: false),
                        ProductGradeId = c.Int(nullable: false),
                        ProductApiId = c.Int(nullable: false),
                        ProductCategoryId = c.Int(nullable: false),
                        PackSize = c.Int(nullable: false),
                        Multiplier = c.Int(nullable: false),
                        ProductUnitId = c.Int(nullable: false),
                        Mrp = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReOrderPoint = c.Single(nullable: false),
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
                    { "DynamicFilter_FinishProduct_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.BrandId)
                .ForeignKey("dbo.ProductApis", t => t.ProductApiId)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategoryId)
                .ForeignKey("dbo.ProductGrades", t => t.ProductGradeId)
                .ForeignKey("dbo.ProductUnits", t => t.ProductUnitId)
                .Index(t => t.ProductName, unique: true)
                .Index(t => t.BrandId)
                .Index(t => t.ProductGradeId)
                .Index(t => t.ProductApiId)
                .Index(t => t.ProductCategoryId)
                .Index(t => t.ProductUnitId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FinishProductFormulas", "RawMaterialId", "dbo.RawMaterials");
            DropForeignKey("dbo.FinishProductFormulas", "FinishProductId", "dbo.FinishProducts");
            DropForeignKey("dbo.FinishProducts", "ProductUnitId", "dbo.ProductUnits");
            DropForeignKey("dbo.FinishProducts", "ProductGradeId", "dbo.ProductGrades");
            DropForeignKey("dbo.FinishProducts", "ProductCategoryId", "dbo.ProductCategories");
            DropForeignKey("dbo.FinishProducts", "ProductApiId", "dbo.ProductApis");
            DropForeignKey("dbo.FinishProducts", "BrandId", "dbo.Brands");
            DropIndex("dbo.FinishProducts", new[] { "ProductUnitId" });
            DropIndex("dbo.FinishProducts", new[] { "ProductCategoryId" });
            DropIndex("dbo.FinishProducts", new[] { "ProductApiId" });
            DropIndex("dbo.FinishProducts", new[] { "ProductGradeId" });
            DropIndex("dbo.FinishProducts", new[] { "BrandId" });
            DropIndex("dbo.FinishProducts", new[] { "ProductName" });
            DropIndex("dbo.FinishProductFormulas", new[] { "RawMaterialId" });
            DropIndex("dbo.FinishProductFormulas", new[] { "FinishProductId" });
            DropTable("dbo.FinishProducts",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_FinishProduct_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.FinishProductFormulas",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_FinishProductFormula_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
