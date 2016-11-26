using Abp.Application.Services.Dto;
using System;

namespace ESLab.SPMS.RawMaterials.Dtos
{
    public class RawMaterialDto : EntityDto
    {

        public int RawMaterialTypeId { get; set; }
        public string RawMaterialTypeName { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string ProductName { get; set; }
        public string Model { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Origin { get; set; }
        public int ProductUnitId { get; set; }
        public string UnitName { get; set; }
        public int ReOrderPoint { get; set; }
        public long CreatorUserId { get; set; }
        public string FullProductName { get; set; }
        public virtual DateTime CreationTime { get; set; }
    }
}
