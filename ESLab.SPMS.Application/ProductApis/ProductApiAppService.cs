using Abp.Application.Services;
using AutoMapper;
using ESLab.SPMS.ProductUnits.Dtos;
using System.Collections.Generic;
using System.Linq;
using ESLab.SPMS.ProductApis.Dtos;
using System;

namespace ESLab.SPMS.ProductApis
{
    public class ProductApiAppService : ApplicationService, IProductApiAppService
    {
        readonly IProductApiRepository _ProductApiRepository;

        public ProductApiAppService(IProductApiRepository ProductApiRepository)
        {
            _ProductApiRepository = ProductApiRepository;
        }

        public void CreateProductApi(CreateProductApiInput input)
        {
            var productapi = new ProductApi { ApiCode = input.ApiCode, ApiName = input.ApiName, CreatorUserId = input.CreatorUserId };
            _ProductApiRepository.Insert(productapi);
        }

        public void DeleteProductApi(DeleteProductApiInput input)
        {
            var productapi = _ProductApiRepository.Get(input.Id);
            productapi.IsDeleted = true;
            _ProductApiRepository.Delete(productapi);
        }

        public GetAllProductApisOutput GetAllProductApis()
        {
            var productapi = _ProductApiRepository.GetAll().OrderBy(b => b.CreationTime);

            return new GetAllProductApisOutput
            {
                ProductApis = Mapper.Map<List<ProductApiDto>>(productapi)
            };
        }

        public void UpdateProductApi(UpdateProductApiInput input)
        {
            var productapi = _ProductApiRepository.Get(input.Id);

            productapi.ApiCode = input.ApiCode;
            productapi.ApiName = input.ApiName;

            _ProductApiRepository.Update(productapi);
        }
    }
}
