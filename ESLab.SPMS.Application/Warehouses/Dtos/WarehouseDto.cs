using Abp.Application.Services.Dto;
using System;

namespace ESLab.SPMS.Warehouses.Dtos
{
    public class WarehouseDto : EntityDto
    {
        public string WarehouseCode { get; set; }
        public string WarehouseName { get; set; }
        public string WarehouseAddress { get; set; }
        public string WarehousePhone { get; set; }
        public long CreatorUserId { get; set; }
        public virtual DateTime CreationTime { get; set; }
    }
}
