using Abp.Application.Services.Dto;
using System;

namespace ESLab.SPMS.Brands.Dtos
{
    public class BrandDto : EntityDto
    {
        public string BrandCode { get; set; }
        public string BrandName { get; set; }
        public MaterialType BrandType { get; set; }
        public long CreatorUserId { get; set; }
        public virtual DateTime CreationTime { get; set; }
    }
}