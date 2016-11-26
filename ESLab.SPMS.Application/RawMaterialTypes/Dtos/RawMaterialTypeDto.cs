using Abp.Application.Services.Dto;
using System;

namespace ESLab.SPMS.RawMaterialTypes.Dtos
{
    public class RawMaterialTypeDto : EntityDto
    {
        public string RawMaterialTypeCode { get; set; }
        public string RawMaterialTypeName { get; set; }
        public long CreatorUserId { get; set; }
        public virtual DateTime CreationTime { get; set; }
    }
}
