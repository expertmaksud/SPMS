using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ESLab.SPMS.ProductUnits;
using ESLab.SPMS.Brands;
using ESLab.SPMS.RawMaterialTypes;
using ESLab.SPMS.ProductGrades;
using ESLab.SPMS.ProductApis;

namespace ESLab.SPMS.Products
{
    public class Product : Entity, IFullAudited
    {
        [Index(IsUnique = true)]
        [StringLength(100)]
        public virtual string ProductName { get; set; }

        public virtual int? RawMaterialTypeId { get; set; }

        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }
        public virtual int BrandId { get; set; }

        [StringLength(40)]
        public virtual string Model { get; set; }

        [StringLength(10)]
        public virtual string Size { get; set; }

        [StringLength(20)]
        public virtual string Color { get; set; }

        [StringLength(20)]
        public virtual string Origin { get; set; }

        [StringLength(10)]
        public virtual string Density { get; set; }

        [ForeignKey("ProductUnitId")]
        public virtual ProductUnit ProductUnit { get; set; }
        public virtual int ProductUnitId { get; set; }

        public virtual int ReOrderPoint { get; set; }

        public virtual int? ProductGradeId { get; set; }

  
        public virtual int? ProductApiId { get; set; }


        public virtual int? ProductCategoryId { get; set; }

        public virtual int? PackSize { get; set; }

        public virtual int? Multiplier { get; set; }

        public virtual decimal? Mrp { get; set; }

        public virtual DateTime CreationTime { get; set; }

        public long? CreatorUserId { get; set; }

        public DateTime? LastModificationTime { get; set; }

        public long? LastModifierUserId { get; set; }

        public long? DeleterUserId { get; set; }

        public DateTime? DeletionTime { get; set; }

        public bool IsDeleted { get; set; }

        public Product()
        {
            CreationTime = DateTime.Now;
        }
    }
}
