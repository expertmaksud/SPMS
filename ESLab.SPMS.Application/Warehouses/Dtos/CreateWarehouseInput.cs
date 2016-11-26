using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace ESLab.SPMS.Warehouses.Dtos
{
    public class CreateWarehouseInput
    {
        [Required]
        public string WarehouseCode { get; set; }

        [Required]
        public string WarehouseName { get; set; }

        public string WarehouseAddress { get; set; }
        public string WarehousePhone { get; set; }

        public long CreatorUserId { get; set; }
    }
}
