using Abp.Application.Services;
using AutoMapper;
using ESLab.SPMS.Warehouses.Dtos;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ESLab.SPMS.Warehouses
{
    public class WarehouseAppService : ApplicationService, IWarehouseAppService
    {
        readonly IWarehouseRepository _WarehouseRepository;
        
        public WarehouseAppService(IWarehouseRepository WarehouseRepository)
        {
            _WarehouseRepository = WarehouseRepository;
        }



        public void CreateWarehouse(CreateWarehouseInput input)
        {
            var warehouse = new Warehouse {
                WarehouseCode = input.WarehouseCode,
                WarehouseName = input.WarehouseName,
                WarehouseAddress = input.WarehouseAddress,
                WarehousePhone = input.WarehousePhone,
                CreatorUserId = input.CreatorUserId
            };
            _WarehouseRepository.Insert(warehouse);
        }

        public void DeleteWarehouse(DeleteWarehouseInput input)
        {
            var warehouse = _WarehouseRepository.Get(input.Id);
            warehouse.IsDeleted = true;
            _WarehouseRepository.Delete(warehouse);
        }

        public GetAllWarehousesOutput GetAllWarehouses()
        {
            var warehouse = _WarehouseRepository.GetAll().OrderBy(b => b.CreationTime);
            return new GetAllWarehousesOutput
            {
                Warehouses = Mapper.Map<List<WarehouseDto>>(warehouse)
            };
        }

        public void UpdateWarehouse(UpdateWarehouseInput input)
        {
            var warehouse = _WarehouseRepository.Get(input.Id);

            warehouse.WarehouseCode = input.WarehouseCode;
            warehouse.WarehouseName = input.WarehouseName;
            warehouse.WarehouseAddress = input.WarehouseAddress;
            warehouse.WarehousePhone = input.WarehousePhone;

            _WarehouseRepository.Update(warehouse);
        }
    }
}
