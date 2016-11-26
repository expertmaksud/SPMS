using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace ESLab.SPMS.RawMaterials.Dtos
{
    public class CreateRawMaterialInput : IInputDto
    {
        [Required]
        public int RawMaterialTypeId { get; set; }

        [Required]
        public int BrandId { get; set; }

        [Required]
        public string ProductName { get; set; }
        
        public string Model { get; set; }

        public string Size { get; set; }

        public string Color { get; set; }

        [Required]
        public string Origin { get; set; }        

        [Required]
        public int ProductUnitId { get; set; }

        public int ReOrderPoint { get; set; }

        public long CreatorUserId { get; set; }
    }
}
