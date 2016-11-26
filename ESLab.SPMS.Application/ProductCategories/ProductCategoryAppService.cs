using Abp.Application.Services;
using AutoMapper;
using ESLab.SPMS.ProductCategories.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace ESLab.SPMS.ProductCategories
{
    public class ProductCategoryAppService : ApplicationService, IProductCategoryAppService
    {
        readonly IProductCategoryRepository _ProductCategoryRepository;

        public ProductCategoryAppService(IProductCategoryRepository ProductCategoryRepository)
        {
            _ProductCategoryRepository = ProductCategoryRepository;
        }

        public void CreateProductCategory(CreateProductCategoryInput input)
        {
            var productcategory = new ProductCategory { CategoryCode = input.CategoryCode, CategoryName = input.CategoryName, CreatorUserId = input.CreatorUserId };
            _ProductCategoryRepository.Insert(productcategory);
        }

        public GetAllProductCategoriesOutput GetAllProductCategories()
        {
            var productcategories = _ProductCategoryRepository.GetAll().OrderBy(b => b.CreationTime);

            return new GetAllProductCategoriesOutput
            {
                ProductCategories = Mapper.Map<List<ProductCategoryDto>>(productcategories)
            };
        }


        public void UpdateProductCategory(UpdateProductCategoryInput input)
        {
            var productcategory = _ProductCategoryRepository.Get(input.Id);

            productcategory.CategoryCode = input.CategoryCode;
            productcategory.CategoryName = input.CategoryName;

            _ProductCategoryRepository.Update(productcategory);
        }

        public void DeleteProductCategory(DeleteProductCategoryInput input)
        {
            var productcategory = _ProductCategoryRepository.Get(input.Id);

            productcategory.IsDeleted = true;


            _ProductCategoryRepository.Delete(productcategory);
        }
    }
}
