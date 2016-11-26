using Abp.Application.Services.Dto;
using System;

namespace ESLab.SPMS.FinishProducts.Dtos
{
    public class FinishProductDto : EntityDto
    {
        public string ProductName { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int ProductGradeId { get; set; }
        public string ProductGradeName { get; set; }
        public string FullProductName { get; set; }
        public int ProductApiId { get; set; }
        public string ProductApiName { get; set; }
        public int ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }
        public int PackSize { get; set; }
        public int Multiplier { get; set; }
        public int ProductUnitId { get; set; }
        public string ProductUnitName { get; set; }
        public decimal Mrp { get; set; }
        public float ReOrderPoint { get; set; }
        public long CreatorUserId { get; set; }
        public virtual DateTime CreationTime { get; set; }
    }
}
