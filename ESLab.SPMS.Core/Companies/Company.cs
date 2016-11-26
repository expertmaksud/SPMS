using Abp.Domain.Entities;
using System;
using Abp.Domain.Entities.Auditing;
using ESLab.SPMS.Users;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ESLab.SPMS.Companies
{
    public class Company : Entity, IFullAudited
    {
        [Index(IsUnique = true)]
        [StringLength(20)]
        public virtual string CompanyCode { get; set; }
        [StringLength(200)]
        public virtual string CompanyName { get; set; }
        public virtual string CompanyAddress { get; set; }
        public virtual string CompanyPhone { get; set; }
        public virtual string CompanyWebsite { get; set; }
        public virtual string CompanyEmail { get; set; }
        public virtual string CompanyLogo { get; set; }

        public virtual DateTime CreationTime { get; set; }

        public long? CreatorUserId { get; set; }

        public DateTime? LastModificationTime { get; set; }

        public long? LastModifierUserId { get; set; }

        public long? DeleterUserId { get; set; }

        public DateTime? DeletionTime { get; set; }

        public bool IsDeleted { get; set; }

        public Company()
        {
            CreationTime = DateTime.Now;
        }
    }
}
