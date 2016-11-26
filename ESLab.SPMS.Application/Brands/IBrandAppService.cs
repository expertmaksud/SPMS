using Abp.Application.Services;
using ESLab.SPMS.Brands.Dtos;
using System.Web.Http;

namespace ESLab.SPMS.Brands
{
    public interface IBrandAppService : IApplicationService
    {
        [HttpPost]
        void CreateBrand(CreateBrandInput input);

        [HttpGet]
        GetAllBrandsOutput GetAllBrands();

        [HttpPost]
        void UpdateBrand(UpdateBrandInput input);

        BrandDto GetByCode(GetByCodeInput input);

        GetAllBrandsOutput GetBrandsByBrandType(GetBrandsByBrandTypeInput input);
    }
}