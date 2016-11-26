using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ESLab.SPMS.Users;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESLab.SPMS.Brands
{
    public class Brand : Entity, IFullAudited
    {
        [Index(IsUnique = true)]
        [StringLength(20)]
        public virtual string BrandCode { get; set; }

        [StringLength(200)]
        public virtual string BrandName { get; set; }

        public virtual MaterialType BrandType { get; set; }

        public virtual DateTime CreationTime { get; set; }

        public long? CreatorUserId { get; set; }

        public DateTime? LastModificationTime { get; set; }

        public long? LastModifierUserId { get; set; }

        public long? DeleterUserId { get; set; }

        public DateTime? DeletionTime { get; set; }

        public bool IsDeleted { get; set; }

        public Brand()
        {
            CreationTime = DateTime.Now;
        }
    }

    public enum MaterialType
    {
        RawMaterial,
        FinishProduct
    }
                                
}