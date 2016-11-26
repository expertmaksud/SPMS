using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ESLab.SPMS.FinishProducts;
using ESLab.SPMS.RawMaterials;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESLab.SPMS.FinishProductFormulas
{
    public class FinishProductFormula : Entity, IFullAudited
    {
        [ForeignKey("FinishProductId")]
        public virtual FinishProduct FinishProduct { get; set; }
        public virtual int FinishProductId { get; set; }

        [ForeignKey("RawMaterialId")]
        public virtual RawMaterial RawMaterial { get; set; }
        public virtual int RawMaterialId { get; set; }

        public virtual float Percentage { get; set; }

        public virtual DateTime CreationTime { get; set; }

        public long? CreatorUserId { get; set; }

        public DateTime? LastModificationTime { get; set; }

        public long? LastModifierUserId { get; set; }

        public long? DeleterUserId { get; set; }

        public DateTime? DeletionTime { get; set; }

        public bool IsDeleted { get; set; }

        public FinishProductFormula()
        {
            CreationTime = DateTime.Now;
        }
    }
}
