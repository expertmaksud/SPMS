using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace ESLab.SPMS.FinishProducts.Dtos
{
    public class UpdateFinishProductInput : IInputDto
    {
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public int BrandId { get; set; }

        [Required]
        public int ProductGradeId { get; set; }

        [Required]
        public int ProductApiId { get; set; }

        [Required]
        public int ProductCategoryId { get; set; }

        [Required]
        public int PackSize { get; set; }

        [Required]
        public int Multiplier { get; set; }

        [Required]
        public int ProductUnitId { get; set; }

        public decimal Mrp { get; set; }

        public float ReOrderPoint { get; set; }
    }
}
