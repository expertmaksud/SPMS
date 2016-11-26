using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ESLab.SPMS.FinishProductFormulas.Dtos;

namespace ESLab.SPMS.FinishProducts.Dtos
{
    public class CreateFinishProductInput : IInputDto
    {
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

        public List<CreateFinishProductFormulaInput> FinishProductFormulaItems { get; set; }

        public long CreatorUserId { get; set; }
    }
}
