using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ESLab.SPMS.ProductUnits;
using ESLab.SPMS.Brands;
using ESLab.SPMS.RawMaterialTypes;

namespace ESLab.SPMS.RawMaterials
{
    public class RawMaterial : Entity, IFullAudited
    {
        [Index(IsUnique = true)]
        [StringLength(100)]
        public virtual string ProductName { get; set; }

        [ForeignKey("RawMaterialTypeId")]
        public virtual RawMaterialType RawMaterialType { get; set; }
        public virtual int RawMaterialTypeId { get; set; }

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

        [ForeignKey("ProductUnitId")]
        public virtual ProductUnit ProductUnit { get; set; }
        public virtual int ProductUnitId { get; set; }

        public virtual int ReOrderPoint { get; set; }

        public virtual DateTime CreationTime { get; set; }

        public long? CreatorUserId { get; set; }

        public DateTime? LastModificationTime { get; set; }

        public long? LastModifierUserId { get; set; }

        public long? DeleterUserId { get; set; }

        public DateTime? DeletionTime { get; set; }

        public bool IsDeleted { get; set; }        

        public RawMaterial()
        {
            CreationTime = DateTime.Now;
        }
    }
}
