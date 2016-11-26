using Abp.Application.Services;
using ESLab.SPMS.RawMaterialTypes.Dtos;

namespace ESLab.SPMS.RawMaterialTypes
{
    public interface IRawMaterialTypeAppService : IApplicationService
    {
        void CreateRawMaterialType(CreateRawMaterialTypeInput input);
        GetAllRawMaterialTypesOutput GetAllRawMaterialTypes();
        void UpdateRawMaterialType(UpdateRawMaterialTypeInput input);
        void DeleteRawMaterialType(DeleteRawMaterialTypeInput input);
    }
}
