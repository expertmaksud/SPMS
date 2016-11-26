using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace ESLab.SPMS.Freights.Dtos
{
    public class UpdateFreightInput : IInputDto
    {
        public int Id { get; set; }
        [Required]
        public string FreightCode { get; set; }
        [Required]
        public string FreightName { get; set; }
    }
}
