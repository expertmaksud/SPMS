using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESLab.SPMS.Warehouses
{
    public class Warehouse : Entity, IFullAudited
    {

        [Index(IsUnique = true)]
        [StringLength(20)]
        public virtual string WarehouseCode { get; set; }

        [Index(IsUnique = true)]
        [StringLength(100)]
        public virtual string WarehouseName { get; set; }

        [StringLength(200)]
        public virtual string WarehouseAddress { get; set; }

        [StringLength(30)]
        public virtual string WarehousePhone { get; set; }

        public virtual DateTime CreationTime { get; set; }

        public long? CreatorUserId { get; set; }

        public DateTime? LastModificationTime { get; set; }

        public long? LastModifierUserId { get; set; }

        public long? DeleterUserId { get; set; }

        public DateTime? DeletionTime { get; set; }

        public bool IsDeleted { get; set; }

        public Warehouse()
        {
            CreationTime = DateTime.Now;
        }
    }
}
