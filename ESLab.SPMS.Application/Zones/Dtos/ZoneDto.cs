using Abp.Application.Services.Dto;
using System;

namespace ESLab.SPMS.Zones.Dtos
{
    public class ZoneDto : EntityDto
    {
        public string ZoneCode { get; set; }
        public string ZoneName { get; set; }
        public long CreatorUserId { get; set; }
        public virtual DateTime CreationTime { get; set; }
    }
}