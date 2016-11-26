using Abp.Application.Services;
using AutoMapper;
using ESLab.SPMS.ProductUnits.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace ESLab.SPMS.ProductUnits
{
    public class ProductUnitAppService : ApplicationService, IProductUnitAppService
    {
        readonly IProductUnitRepository _ProductUnitRepository;

        public ProductUnitAppService(IProductUnitRepository ProductUnitRepository)
        {
            _ProductUnitRepository = ProductUnitRepository;
        }

        public void CreateProductUnit(CreateProductUnitInput input)
        {
            var productunit = new ProductUnit { UnitCode = input.UnitCode, UnitName = input.UnitName, UnitToKg = input.UnitToKg, CreatorUserId = input.CreatorUserId };
            _ProductUnitRepository.Insert(productunit);
        }

        public void DeleteProductUnit(DeleteProductUnitInput input)
        {
            var productunit = _ProductUnitRepository.Get(input.Id);
            productunit.IsDeleted = true;
            _ProductUnitRepository.Delete(productunit);
        }

        public GetAllProductUnitsOutput GetAllProductUnits()
        {
            var productunit = _ProductUnitRepository.GetAll().OrderBy(b => b.CreationTime);

            return new GetAllProductUnitsOutput
            {
                ProductUnits = Mapper.Map<List<ProductUnitDto>>(productunit)
            };
        }

        public void UpdateProductUnit(UpdateProductUnitInput input)
        {
            var productunit = _ProductUnitRepository.Get(input.Id);

            productunit.UnitCode = input.UnitCode;
            productunit.UnitName = input.UnitName;
            productunit.UnitToKg = input.UnitToKg;

            _ProductUnitRepository.Update(productunit);
        }
    }
}
