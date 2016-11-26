using Abp.Application.Services.Dto;
using System;

namespace ESLab.SPMS.Freights.Dtos
{
    public class FreightDto : EntityDto
    {
        public string FreightCode { get; set; }
        public string FreightName { get; set; }
        public long CreatorUserId { get; set; }
        public virtual DateTime CreationTime { get; set; }
    }
}
