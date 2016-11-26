using Abp.Application.Services;
using ESLab.SPMS.FinishProducts.Dtos;

namespace ESLab.SPMS.FinishProducts
{
    public interface IFinishProductAppService : IApplicationService
    {
        void CreateFinishProduct(CreateFinishProductInput input);
        GetAllFinishProductsOutput GetAllFinishProducts();
        void UpdateFinishProduct(UpdateFinishProductInput input);
        void DeleteFinishProduct(DeleteFinishProductInput input);
        GetFinishProductDetailsByIdOutput GetFinishProductDetailsById(GetFinishProductDetailsByIdInput input);
    }
}
