using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace ESLab.SPMS.Freights.Dtos
{
    public class CreateFreightInput : IInputDto
    {
        [Required]
        public string FreightCode { get; set; }

        [Required]
        public string FreightName { get; set; }
        public long CreatorUserId { get; set; }
      
    }
}
