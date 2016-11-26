using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace ESLab.SPMS.ProductCategories.Dtos
{
    public class CreateProductCategoryInput : IInputDto
    {
        [Required]
        public string CategoryCode { get; set; }

        [Required]
        public string CategoryName { get; set; }
        public long CreatorUserId { get; set; }

    }
}
