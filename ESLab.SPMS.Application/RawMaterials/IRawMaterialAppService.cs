using Abp.Application.Services;
using ESLab.SPMS.RawMaterials.Dtos;
using System.Web.Http;

namespace ESLab.SPMS.RawMaterials
{
    public interface IRawMaterialAppService : IApplicationService
    {
        void CreateRawMaterial(CreateRawMaterialInput input);
        [HttpGet]
        GetAllRawMaterialsOutput GetAllRawMaterials();
        void UpdateRawMaterial(UpdateRawMaterialInput input);
        void DeleteRawMaterial(DeleteRawMaterialInput input);
    }
}
