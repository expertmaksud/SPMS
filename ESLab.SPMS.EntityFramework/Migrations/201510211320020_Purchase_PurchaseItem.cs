namespace ESLab.SPMS.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Purchase_PurchaseItem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AbpFeatures",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128),
                        Value = c.String(nullable: false, maxLength: 2000),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        EditionId = c.Int(),
                        TenantId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpEditions", t => t.EditionId, cascadeDelete: true)
                .Index(t => t.EditionId);
            
            CreateTable(
                "dbo.AbpEditions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 32),
                        DisplayName = c.String(nullable: false, maxLength: 64),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Edition_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PurchaseItems",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PurchaseId = c.Long(nullable: false),
                        RawMaterialId = c.Int(nullable: false),
                        PurchaseQuantity = c.Single(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
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
                    { "DynamicFilter_PurchaseItem_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Purchases", t => t.PurchaseId, cascadeDelete: true)
                .ForeignKey("dbo.RawMaterials", t => t.RawMaterialId, cascadeDelete: true)
                .Index(t => t.PurchaseId)
                .Index(t => t.RawMaterialId);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PurchaseType = c.Int(nullable: false),
                        LcNumber = c.String(maxLength: 100),
                        LcDate = c.DateTime(nullable: false),
                        PoNumber = c.String(maxLength: 100),
                        PoDate = c.DateTime(nullable: false),
                        Etd = c.DateTime(nullable: false),
                        Eta = c.DateTime(nullable: false),
                        VendorId = c.Int(nullable: false),
                        Remarks = c.String(maxLength: 300),
                        Status = c.Int(nullable: false),
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
                    { "DynamicFilter_Purchase_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vendors", t => t.VendorId, cascadeDelete: true)
                .Index(t => t.LcNumber, unique: true)
                .Index(t => t.VendorId);
            
            AddColumn("dbo.AbpAuditLogs", "ImpersonatorUserId", c => c.Long());
            AddColumn("dbo.AbpAuditLogs", "ImpersonatorTenantId", c => c.Int());
            AddColumn("dbo.AbpAuditLogs", "CustomData", c => c.String());
            AddColumn("dbo.AbpTenants", "EditionId", c => c.Int());
            AlterColumn("dbo.AbpUsers", "PasswordResetCode", c => c.String(maxLength: 328));
            CreateIndex("dbo.AbpTenants", "EditionId");
            AddForeignKey("dbo.AbpTenants", "EditionId", "dbo.AbpEditions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AbpTenants", "EditionId", "dbo.AbpEditions");
            DropForeignKey("dbo.PurchaseItems", "RawMaterialId", "dbo.RawMaterials");
            DropForeignKey("dbo.PurchaseItems", "PurchaseId", "dbo.Purchases");
            DropForeignKey("dbo.Purchases", "VendorId", "dbo.Vendors");
            DropForeignKey("dbo.AbpFeatures", "EditionId", "dbo.AbpEditions");
            DropIndex("dbo.AbpTenants", new[] { "EditionId" });
            DropIndex("dbo.Purchases", new[] { "VendorId" });
            DropIndex("dbo.Purchases", new[] { "LcNumber" });
            DropIndex("dbo.PurchaseItems", new[] { "RawMaterialId" });
            DropIndex("dbo.PurchaseItems", new[] { "PurchaseId" });
            DropIndex("dbo.AbpFeatures", new[] { "EditionId" });
            AlterColumn("dbo.AbpUsers", "PasswordResetCode", c => c.String(maxLength: 128));
            DropColumn("dbo.AbpTenants", "EditionId");
            DropColumn("dbo.AbpAuditLogs", "CustomData");
            DropColumn("dbo.AbpAuditLogs", "ImpersonatorTenantId");
            DropColumn("dbo.AbpAuditLogs", "ImpersonatorUserId");
            DropTable("dbo.Purchases",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Purchase_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.PurchaseItems",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_PurchaseItem_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpEditions",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Edition_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpFeatures");
        }
    }
}
