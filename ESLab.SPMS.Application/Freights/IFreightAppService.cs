using Abp.Application.Services;
using ESLab.SPMS.Freights.Dtos;

namespace ESLab.SPMS.Freights
{
    public interface IFreightAppService : IApplicationService
    {
        void CreateFreight(CreateFreightInput input);
        GetAllFreightsOutput GetAllFreights();
        void UpdateFreight(UpdateFreightInput input);
        void DeleteFreight(DeleteFreightInput input);
    }
}
