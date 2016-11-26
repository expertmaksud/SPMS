using Abp.Application.Services;
using ESLab.SPMS.ProductUnits.Dtos;

namespace ESLab.SPMS.ProductUnits
{
    public interface IProductUnitAppService : IApplicationService
    {
        void CreateProductUnit(CreateProductUnitInput input);
        GetAllProductUnitsOutput GetAllProductUnits();
        void UpdateProductUnit(UpdateProductUnitInput input);
        void DeleteProductUnit(DeleteProductUnitInput input);
    }
}