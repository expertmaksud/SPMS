using Abp.Zero.EntityFramework;
using ESLab.SPMS.Authorization.Roles;
using ESLab.SPMS.Brands;
using ESLab.SPMS.Companies;
using ESLab.SPMS.Distributors;
using ESLab.SPMS.Freights;
using ESLab.SPMS.MultiTenancy;
using ESLab.SPMS.Procurement;
using ESLab.SPMS.Sales;
using ESLab.SPMS.Inventory;
using ESLab.SPMS.Procurement.PurchaseItems;
using ESLab.SPMS.Procurement.Purchases;
using ESLab.SPMS.ProductApis;
using ESLab.SPMS.ProductCategories;
using ESLab.SPMS.ProductGrades;
using ESLab.SPMS.ProductUnits;
using ESLab.SPMS.RawMaterials;
using ESLab.SPMS.RawMaterialTypes;
using ESLab.SPMS.Users;
using ESLab.SPMS.Vendors;
using ESLab.SPMS.Zones;
using ESLab.SPMS.Warehouses;
using ESLab.SPMS.FinishProducts;
using ESLab.SPMS.FinishProductFormulas;
using System.Data.Common;
using System.Data.Entity;

using System;
using ESLab.SPMS.Inventory.Stocks;
using ESLab.SPMS.Production;

namespace ESLab.SPMS.EntityFramework
{
    public class SPMSDbContext : AbpZeroDbContext<Tenant, Role, User>, IPurchaseDBContext, IInventoryDBContext, ISalesDBContext, IProductionDBContext
    {
        //TODO: Define an IDbSet for each Entity...

        public SPMSDbContext()
                    : base("Default")
        {
        }

        public SPMSDbContext(string nameOrConnectionString)
                    : base(nameOrConnectionString)
        {
        }

        //This constructor is used in tests
        public SPMSDbContext(DbConnection connection)
            : base(connection, true)
        {
        }

        //Example:
        //public virtual IDbSet<User> Users { get; set; }
        public virtual IDbSet<Brand> Brands { get; set; }

        public virtual IDbSet<Company> Companies { get; set; }
        public virtual IDbSet<Distributor> Distributors { get; set; }
        public virtual IDbSet<Freight> Freights { get; set; }
        public virtual IDbSet<ProductApi> ProductApis { get; set; }
        public virtual IDbSet<ProductCategory> ProductCategories { get; set; }
        public virtual IDbSet<ProductGrade> ProductGrades { get; set; }
        public virtual IDbSet<ProductUnit> ProductUnits { get; set; }
        public virtual IDbSet<PurchaseItem> PurchaseItems { get; set; }
        public virtual IDbSet<Purchase> Purchases { get; set; }
        public virtual IDbSet<RawMaterial> RawMaterials { get; set; }
        public virtual IDbSet<RawMaterialType> RawMaterialTypes { get; set; }
        public virtual IDbSet<Vendor> Vendors { get; set; }
        public virtual IDbSet<Zone> Zones { get; set; }
        public virtual IDbSet<Warehouse> Warehouses { get; set; }
        public virtual IDbSet<FinishProduct> FinishProducts { get; set; }
        public virtual IDbSet<FinishProductFormula> FinishProductFormulas { get; set; }
        public virtual IDbSet<Stock> Stocks { get; set; }

        /* NOTE:
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in SPMSDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of SPMSDbContext since ABP automatically handles it.
         */
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}