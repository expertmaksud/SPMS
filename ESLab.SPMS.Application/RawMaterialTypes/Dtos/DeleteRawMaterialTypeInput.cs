using Abp.Application.Services.Dto;

namespace ESLab.SPMS.RawMaterialTypes.Dtos
{
    public class DeleteRawMaterialTypeInput : IInputDto
    {
        public int Id { get; set; }
    }
}
