using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace ESLab.SPMS.ProductApis.Dtos
{
    public class CreateProductApiInput : IInputDto
    {
        [Required]
        public string ApiCode { get; set; }

        [Required]
        public string ApiName { get; set; }
        public long CreatorUserId { get; set; }
    }
}
