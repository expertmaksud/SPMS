using Abp.Application.Services;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using ESLab.SPMS.FinishProductFormulas.Dtos;
using System;

namespace ESLab.SPMS.FinishProductFormulas
{
    public class FinishProductFormulaAppService : ApplicationService, IFinishProductFormulaAppService
    {
        readonly IFinishProductFormulaRepository _FinishProductFormulaRepository;

        public FinishProductFormulaAppService(IFinishProductFormulaRepository FinishProductForumulaRepository)
        {
            _FinishProductFormulaRepository = FinishProductForumulaRepository;
        }

        public void CreateFinishProductFormula(CreateFinishProductFormulaInput input)
        {
            var finishproductformula = new FinishProductFormula
            {
                FinishProductId = input.FinishProductId,
                RawMaterialId = input.RawMaterialId,
                Percentage = input.Percentage,
                CreatorUserId = input.CreatorUserId
            };

            _FinishProductFormulaRepository.Insert(finishproductformula);
        }

        public void DeleteFinishProductFormula(DeleteFinishProductFormulaInput input)
        {
            var finishproductformula = _FinishProductFormulaRepository.Get(input.Id);
            finishproductformula.IsDeleted = true;
            _FinishProductFormulaRepository.Delete(finishproductformula);
        }

        public GetAllFinishProductFormulasOutput GetAllFinishProductFormulas()
        {
            var finishproductformulas = _FinishProductFormulaRepository.GetAll().OrderBy(b => b.CreationTime);

            return new GetAllFinishProductFormulasOutput
            {
                FinishProductFormulas = Mapper.Map<List<FinishProductFormulaDto>>(finishproductformulas)
            };
        }

        public void UpdateFinishProductFormula(UpdateFinishProductFormulaInput input)
        {
            var finishproductformula = _FinishProductFormulaRepository.Get(input.Id);

            finishproductformula.FinishProductId = input.FinishProductId;
            finishproductformula.RawMaterialId = input.RawMaterialId;
            finishproductformula.Percentage = input.Percentage;           

            _FinishProductFormulaRepository.Update(finishproductformula);
        }
    }
}
