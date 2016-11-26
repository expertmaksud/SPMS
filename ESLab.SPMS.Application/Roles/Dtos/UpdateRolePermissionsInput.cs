using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ESLab.SPMS.Roles.Dtos
{
    public class UpdateRolePermissionsInput : IInputDto
    {
        [Range(1, int.MaxValue)]
        public int RoleId { get; set; }

        [Required]
        public List<string> GrantedPermissionNames { get; set; }
    }
}