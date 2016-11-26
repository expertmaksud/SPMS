using Abp.Application.Services.Dto;

namespace ESLab.SPMS.ProductUnits.Dtos
{
    public class DeleteProductUnitInput : IInputDto
    {
        public int Id { get; set; }
    }
}
