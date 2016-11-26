using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESLab.SPMS.ProductUnits
{
    public class ProductUnit : Entity, IFullAudited
    {
        [Index(IsUnique = true)]
        [StringLength(20)]
        public virtual string UnitCode { get; set; }

        [StringLength(20)]
        public virtual string UnitName { get; set; }

        public virtual float UnitToKg { get; set; }
        
        public virtual DateTime CreationTime { get; set; }

        public long? CreatorUserId { get; set; }

        public DateTime? LastModificationTime { get; set; }

        public long? LastModifierUserId { get; set; }

        public long? DeleterUserId { get; set; }

        public DateTime? DeletionTime { get; set; }

        public bool IsDeleted { get; set; }

        public ProductUnit()
        {
            CreationTime = DateTime.Now;
        }
    }
}