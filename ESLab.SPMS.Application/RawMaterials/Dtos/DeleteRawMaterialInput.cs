using Abp.Application.Services.Dto;

namespace ESLab.SPMS.RawMaterials.Dtos
{
    public class DeleteRawMaterialInput : IInputDto
    {
        public int Id { get; set; }
    }
}
