using Abp.Application.Services;
using ESLab.SPMS.Roles.Dtos;
using System.Threading.Tasks;

namespace ESLab.SPMS.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}