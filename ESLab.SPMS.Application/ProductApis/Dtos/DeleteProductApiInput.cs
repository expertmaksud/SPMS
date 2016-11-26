using Abp.Application.Services.Dto;

namespace ESLab.SPMS.ProductApis.Dtos
{
    public class DeleteProductApiInput : IInputDto
    {
        public int Id { get; set; }
    }
}
