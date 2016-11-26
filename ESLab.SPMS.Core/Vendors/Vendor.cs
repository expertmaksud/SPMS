using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESLab.SPMS.Vendors
{
    public class Vendor : Entity, IFullAudited
    {
        [Index(IsUnique = true)]
        [StringLength(20)]
        public virtual string VendorCode { get; set; }

        [StringLength(200)]
        public virtual string VendorName { get; set; }

        public virtual string VendorAddress { get; set; }
        public virtual string VendorContactPerson { get; set; }
        public virtual string VendorContactNumber { get; set; }
        public virtual string VendorContactEmail { get; set; }
        public virtual string VendorWebsite { get; set; }
        public virtual string VendorFax { get; set; }
        public virtual string VendorBankDetails { get; set; }

        public virtual DateTime CreationTime { get; set; }

        public long? CreatorUserId { get; set; }

        public DateTime? LastModificationTime { get; set; }

        public long? LastModifierUserId { get; set; }

        public long? DeleterUserId { get; set; }

        public DateTime? DeletionTime { get; set; }

        public bool IsDeleted { get; set; }

        public Vendor()
        {
            CreationTime = DateTime.Now;
        }
    }
}