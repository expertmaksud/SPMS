using Abp.Application.Services;
using ESLab.SPMS.FinishProductFormulas.Dtos;

namespace ESLab.SPMS.FinishProductFormulas
{
    public interface IFinishProductFormulaAppService : IApplicationService
    {
        void CreateFinishProductFormula(CreateFinishProductFormulaInput input);
        GetAllFinishProductFormulasOutput GetAllFinishProductFormulas();
        void UpdateFinishProductFormula(UpdateFinishProductFormulaInput input);
        void DeleteFinishProductFormula(DeleteFinishProductFormulaInput input);
    }
}
