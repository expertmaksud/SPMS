using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace ESLab.SPMS.RawMaterialTypes.Dtos
{
    public class CreateRawMaterialTypeInput : IInputDto
    {
        [Required]
        public string RawMaterialTypeCode { get; set; }

        [Required]
        public string RawMaterialTypeName { get; set; }
        public long CreatorUserId { get; set; }
    }
}
