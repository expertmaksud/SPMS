using Abp.Application.Services;
using ESLab.SPMS.ProductApis.Dtos;

namespace ESLab.SPMS.ProductApis
{
    public interface IProductApiAppService : IApplicationService
    {
        void CreateProductApi(CreateProductApiInput input);
        GetAllProductApisOutput GetAllProductApis();
        void UpdateProductApi(UpdateProductApiInput input);
        void DeleteProductApi(DeleteProductApiInput input);
    }
}
