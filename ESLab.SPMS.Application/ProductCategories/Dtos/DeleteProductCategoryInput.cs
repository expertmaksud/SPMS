using Abp.Application.Services.Dto;

namespace ESLab.SPMS.ProductCategories.Dtos
{
    public class DeleteProductCategoryInput : IInputDto
    {
        public int Id { get; set; }
    }
}
