using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace ESLab.SPMS.RawMaterialTypes.Dtos
{
    public class UpdateRawMaterialTypeInput : IInputDto
    {
        public int Id { get; set; }
        [Required]
        public string RawMaterialTypeCode { get; set; }
        [Required]
        public string RawMaterialTypeName { get; set; }
    }
}
