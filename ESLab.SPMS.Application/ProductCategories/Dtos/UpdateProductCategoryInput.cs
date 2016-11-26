using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace ESLab.SPMS.ProductCategories.Dtos
{
    public class UpdateProductCategoryInput : IInputDto
    {
        public int Id { get; set; }
        [Required]
        public string CategoryCode { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
