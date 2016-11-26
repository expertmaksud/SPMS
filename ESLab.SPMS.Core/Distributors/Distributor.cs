using Abp.Domain.Entities;
using System;
using Abp.Domain.Entities.Auditing;
using ESLab.SPMS.Users;
using ESLab.SPMS.Zones;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ESLab.SPMS.Distributors
{
    public class Distributor: Entity, IFullAudited
    {
        [Index(IsUnique = true)]
        [StringLength(20)]
        public virtual string DistributorCode { get; set; }
        [StringLength(200)]
        public virtual string DistributorName { get; set; }
        public virtual string DistributorAddress { get; set; }
        public virtual string DistributorCity { get; set; }
        public virtual string DistributorCountry { get; set; }
        public virtual string DistributorContactPerson { get; set; }
        public virtual string DistributorJobTitle { get; set; }
        public virtual string DistributorMobileNumber { get; set; }
        public virtual string DistributorContactEmail { get; set; }
        public virtual string DistributorHomePhone { get; set; }
        public virtual string DistributorFaxNumber { get; set; }

        public virtual int? ZoneId { get; set; }
        [ForeignKey("ZoneId")]
        public virtual Zone ZoneID { get; set; }

        public virtual DateTime CreationTime { get; set; }

        public long? CreatorUserId { get; set; }

        public DateTime? LastModificationTime { get; set; }

        public long? LastModifierUserId { get; set; }

        public long? DeleterUserId { get; set; }

        public DateTime? DeletionTime { get; set; }

        public bool IsDeleted { get; set; }

        public Distributor()
        {
            CreationTime = DateTime.Now;
        }
    }
}
