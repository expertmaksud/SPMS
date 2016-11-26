using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace ESLab.SPMS.FinishProductFormulas.Dtos
{
    public class CreateFinishProductFormulaInput : IInputDto
    {
        [Required]
        public int FinishProductId { get; set; }

        [Required]
        public int RawMaterialId { get; set; }

        [Required]
        public float Percentage { get; set; }

        public long CreatorUserId { get; set; }
    }
}
