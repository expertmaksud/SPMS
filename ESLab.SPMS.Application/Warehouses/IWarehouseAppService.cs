using Abp.Application.Services;
using ESLab.SPMS.Warehouses.Dtos;

namespace ESLab.SPMS.Warehouses
{
    public interface IWarehouseAppService : IApplicationService
    {
        void CreateWarehouse(CreateWarehouseInput input);
        GetAllWarehousesOutput GetAllWarehouses();
        void UpdateWarehouse(UpdateWarehouseInput input);
        void DeleteWarehouse(DeleteWarehouseInput input);
    }
}
