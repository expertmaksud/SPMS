using Abp.Application.Services.Dto;
using System;

namespace ESLab.SPMS.ProductUnits.Dtos
{
    public class ProductUnitDto : EntityDto
    {
        public string UnitCode { get; set; }
        public string UnitName { get; set; }
        public float UnitToKg { get; set; }
        public long CreatorUserId { get; set; }
        public virtual DateTime CreationTime { get; set; }
    }
}
