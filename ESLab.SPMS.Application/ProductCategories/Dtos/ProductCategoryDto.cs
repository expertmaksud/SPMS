using Abp.Application.Services.Dto;
using System;

namespace ESLab.SPMS.ProductCategories.Dtos
{
    public class ProductCategoryDto : EntityDto
    {
        public string CategoryCode { get; set; }
        public string CategoryName { get; set; }
        public long CreatorUserId { get; set; }
        public virtual DateTime CreationTime { get; set; }
    }
}
