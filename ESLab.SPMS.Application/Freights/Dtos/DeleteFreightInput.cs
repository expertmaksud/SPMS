using Abp.Application.Services.Dto;

namespace ESLab.SPMS.Freights.Dtos
{
    public class DeleteFreightInput : IInputDto
    {
        public int Id { get; set; }
    }
}
