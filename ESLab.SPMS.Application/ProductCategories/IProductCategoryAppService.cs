using Abp.Application.Services;
using ESLab.SPMS.ProductCategories.Dtos;

namespace ESLab.SPMS.ProductCategories
{
    public interface IProductCategoryAppService : IApplicationService
    {
        void CreateProductCategory(CreateProductCategoryInput input);
        GetAllProductCategoriesOutput GetAllProductCategories();
        void UpdateProductCategory(UpdateProductCategoryInput input);
        void DeleteProductCategory(DeleteProductCategoryInput input);       
    }
}
