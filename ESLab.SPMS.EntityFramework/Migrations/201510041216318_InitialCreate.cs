namespace ESLab.SPMS.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BrandCode = c.String(maxLength: 20),
                        BrandName = c.String(maxLength: 200),
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
                    { "DynamicFilter_Brand_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.BrandCode, unique: true);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyCode = c.String(maxLength: 20),
                        CompanyName = c.String(maxLength: 200),
                        CompanyAddress = c.String(),
                        CompanyPhone = c.String(),
                        CompanyWebsite = c.String(),
                        CompanyEmail = c.String(),
                        CompanyLogo = c.String(),
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
                    { "DynamicFilter_Company_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.CompanyCode, unique: true);
            
            CreateTable(
                "dbo.Distributors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DistributorCode = c.String(maxLength: 20),
                        DistributorName = c.String(maxLength: 200),
                        DistributorAddress = c.String(),
                        DistributorCity = c.String(),
                        DistributorCountry = c.String(),
                        DistributorContactPerson = c.String(),
                        DistributorJobTitle = c.String(),
                        DistributorMobileNumber = c.String(),
                        DistributorContactEmail = c.String(),
                        DistributorHomePhone = c.String(),
                        DistributorFaxNumber = c.String(),
                        ZoneId = c.Int(nullable: false),
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
                    { "DynamicFilter_Distributor_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Zones", t => t.ZoneId, cascadeDelete: true)
                .Index(t => t.DistributorCode, unique: true)
                .Index(t => t.ZoneId);
            
            CreateTable(
                "dbo.Zones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ZoneCode = c.String(maxLength: 20),
                        ZoneName = c.String(maxLength: 200),
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
                    { "DynamicFilter_Zone_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.ZoneCode, unique: true);
            
            CreateTable(
                "dbo.Freights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FreightCode = c.String(maxLength: 20),
                        FreightName = c.String(maxLength: 200),
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
                    { "DynamicFilter_Freight_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.FreightCode, unique: true);
            
            CreateTable(
                "dbo.ProductApis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApiCode = c.String(maxLength: 20),
                        ApiName = c.String(maxLength: 200),
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
                    { "DynamicFilter_ProductApi_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.ApiCode, unique: true);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryCode = c.String(maxLength: 20),
                        CategoryName = c.String(maxLength: 20),
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
                    { "DynamicFilter_ProductCategory_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.CategoryCode, unique: true);
            
            CreateTable(
                "dbo.ProductGrades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GradeCode = c.String(maxLength: 20),
                        GradeName = c.String(maxLength: 200),
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
                    { "DynamicFilter_ProductGrade_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.GradeCode, unique: true);
            
            CreateTable(
                "dbo.ProductUnits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UnitCode = c.String(maxLength: 20),
                        UnitName = c.String(maxLength: 20),
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
                    { "DynamicFilter_ProductUnit_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UnitCode, unique: true);
            
            CreateTable(
                "dbo.RawMaterialTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RawMaterialTypeCode = c.String(maxLength: 20),
                        RawMaterialTypeName = c.String(maxLength: 200),
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
                    { "DynamicFilter_RawMaterialType_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.RawMaterialTypeCode, unique: true);
            
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VendorCode = c.String(maxLength: 20),
                        VendorName = c.String(maxLength: 200),
                        VendorAddress = c.String(),
                        VendorContactPerson = c.String(),
                        VendorContactNumber = c.String(),
                        VendorContactEmail = c.String(),
                        VendorWebsite = c.String(),
                        VendorFax = c.String(),
                        VendorBankDetails = c.String(),
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
                    { "DynamicFilter_Vendor_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.VendorCode, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Distributors", "ZoneId", "dbo.Zones");
            DropIndex("dbo.Vendors", new[] { "VendorCode" });
            DropIndex("dbo.RawMaterialTypes", new[] { "RawMaterialTypeCode" });
            DropIndex("dbo.ProductUnits", new[] { "UnitCode" });
            DropIndex("dbo.ProductGrades", new[] { "GradeCode" });
            DropIndex("dbo.ProductCategories", new[] { "CategoryCode" });
            DropIndex("dbo.ProductApis", new[] { "ApiCode" });
            DropIndex("dbo.Freights", new[] { "FreightCode" });
            DropIndex("dbo.Zones", new[] { "ZoneCode" });
            DropIndex("dbo.Distributors", new[] { "ZoneId" });
            DropIndex("dbo.Distributors", new[] { "DistributorCode" });
            DropIndex("dbo.Companies", new[] { "CompanyCode" });
            DropIndex("dbo.Brands", new[] { "BrandCode" });
            DropTable("dbo.Vendors",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Vendor_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.RawMaterialTypes",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_RawMaterialType_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.ProductUnits",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ProductUnit_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.ProductGrades",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ProductGrade_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.ProductCategories",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ProductCategory_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.ProductApis",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ProductApi_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Freights",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Freight_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Zones",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Zone_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Distributors",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Distributor_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Companies",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Company_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Brands",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Brand_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
