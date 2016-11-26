using Abp.Application.Services;
using ESLab.SPMS.Distributors.Dtos;

namespace ESLab.SPMS.Distributors
{
    public interface IDistributorAppService : IApplicationService
    {
        void CreateDistributor(CreateDistributorInput input);
        GetAllDistributorsOutput GetAllDistributors();
        void UpdateDistributor(UpdateDistributorInput input);
        void DeleteDistributor(DeleteDistributorInput input);
    }
}
