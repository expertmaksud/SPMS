using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace ESLab.SPMS.ProductApis.Dtos
{
    public class UpdateProductApiInput : IInputDto
    {
        public int Id { get; set; }
        [Required]
        public string ApiCode { get; set; }
        [Required]
        public string ApiName { get; set; }
    }
}
