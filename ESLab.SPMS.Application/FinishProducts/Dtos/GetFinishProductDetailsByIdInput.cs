using Abp.Application.Services.Dto;

namespace ESLab.SPMS.FinishProducts.Dtos
{
    public class GetFinishProductDetailsByIdInput : IInputDto
    {
        public int Id { get; set; }
    }
}
