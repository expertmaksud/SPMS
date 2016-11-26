using Abp.Application.Services.Dto;

namespace ESLab.SPMS.Warehouses.Dtos
{
    public class DeleteWarehouseInput : IInputDto
    {
        public int Id { get; set; }
    }

}
