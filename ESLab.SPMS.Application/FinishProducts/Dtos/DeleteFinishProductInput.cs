using Abp.Application.Services.Dto;

namespace ESLab.SPMS.FinishProducts.Dtos
{
    public class DeleteFinishProductInput : IInputDto
    {
        public int Id { get; set; }
    }
}
