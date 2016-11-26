using Abp.Application.Services.Dto;
using System;

namespace ESLab.SPMS.ProductApis.Dtos
{
    public class ProductApiDto : EntityDto
    {
        public string ApiCode { get; set; }
        public string ApiName { get; set; }
        public long CreatorUserId { get; set; }
        public virtual DateTime CreationTime { get; set; }
    }
}
