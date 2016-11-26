using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace ESLab.SPMS.ProductUnits.Dtos
{
    public class CreateProductUnitInput : IInputDto
    {
        [Required]
        public string UnitCode { get; set; }

        [Required]
        public string UnitName { get; set; }

        [Required]
        public float UnitToKg { get; set; }

        public long CreatorUserId { get; set; }
    }
}
