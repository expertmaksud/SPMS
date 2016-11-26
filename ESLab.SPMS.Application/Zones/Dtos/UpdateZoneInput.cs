using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESLab.SPMS.Zones.Dtos
{
    public class UpdateZoneInput : IInputDto
    {
        public int Id { get; set; }
        [Required]
        public string ZoneCode { get; set; }
        [Required]
        public string ZoneName { get; set; }

    }
}