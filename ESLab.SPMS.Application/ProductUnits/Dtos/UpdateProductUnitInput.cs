using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace ESLab.SPMS.ProductUnits.Dtos
{
    public class UpdateProductUnitInput : IInputDto
    {
        public int Id { get; set; }
        [Required]
        public string UnitCode { get; set; }
        [Required]
        public string UnitName { get; set; }
        [Required]
        public float UnitToKg { get; set; }
    }
}
