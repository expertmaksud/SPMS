using Abp.Application.Services;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using ESLab.SPMS.FinishProducts.Dtos;
using System;
using ESLab.SPMS.FinishProductFormulas;
using ESLab.SPMS.FinishProductFormulas.Dtos;

namespace ESLab.SPMS.FinishProducts
{
    public class FinishProductAppService : ApplicationService, IFinishProductAppService
    {
        readonly IFinishProductRepository _FinishProductRepository;
        readonly IFinishProductFormulaAppService _FinishProductFormulaAppService;

        public FinishProductAppService(IFinishProductRepository FinishProductRepository, IFinishProductFormulaAppService FinishProductFormulaAppService)
        {
            _FinishProductRepository = FinishProductRepository;
            _FinishProductFormulaAppService = FinishProductFormulaAppService;
        }

        public void CreateFinishProduct(CreateFinishProductInput input)
        {
            var finishproduct = new FinishProduct
            {
                ProductName = input.ProductName,
                BrandId = input.BrandId,
                ProductGradeId = input.ProductGradeId,
                ProductApiId = input.ProductApiId,
                ProductCategoryId = input.ProductCategoryId,
                PackSize = input.PackSize,
                Multiplier = input.Multiplier,
                ProductUnitId = input.ProductUnitId,
                Mrp = input.Mrp,
                ReOrderPoint = input.ReOrderPoint,
                CreatorUserId = input.CreatorUserId
            };

            var newFinishProductId = _FinishProductRepository.InsertAndGetId(finishproduct);
            foreach (var item in input.FinishProductFormulaItems)
            {
                item.FinishProductId = newFinishProductId;                
                _FinishProductFormulaAppService.CreateFinishProductFormula(item);
            }
        }

        public void DeleteFinishProduct(DeleteFinishProductInput input)
        {
            var finishproduct = _FinishProductRepository.Get(input.Id);
            finishproduct.IsDeleted = true;
            _FinishProductRepository.Delete(finishproduct);
        }

        public GetAllFinishProductsOutput GetAllFinishProducts()
        {
            var finishProducts = _FinishProductRepository.GetAll().OrderBy(b => b.CreationTime);

            return new GetAllFinishProductsOutput
            {
                FinishProducts = Mapper.Map<List<FinishProductDto>>(finishProducts)
            };
        }

        public void UpdateFinishProduct(UpdateFinishProductInput input)
        {
            var finishproduct = _FinishProductRepository.Get(input.Id);

            finishproduct.ProductName = input.ProductName;
            finishproduct.BrandId = input.BrandId;
            finishproduct.ProductGradeId = input.ProductGradeId;
            finishproduct.ProductApiId = input.ProductApiId;
            finishproduct.ProductCategoryId = input.ProductCategoryId;
            finishproduct.PackSize = input.PackSize;
            finishproduct.Multiplier = input.Multiplier;
            finishproduct.ProductUnitId = input.ProductUnitId;
            finishproduct.Mrp = input.Mrp;
            finishproduct.ReOrderPoint = input.ReOrderPoint;

            _FinishProductRepository.Update(finishproduct);
        }

        public GetFinishProductDetailsByIdOutput GetFinishProductDetailsById(GetFinishProductDetailsByIdInput input)
        {
            var finishProduct = _FinishProductRepository.Get(input.Id);

            return new GetFinishProductDetailsByIdOutput
            {
                FinishProduct = Mapper.Map<FinishProductDto>(finishProduct),
                FinishProductFormulaItems = Mapper.Map<List<FinishProductFormulaDto>>(finishProduct.FinishProductFormulaItems)
            };
        }
    }
}
