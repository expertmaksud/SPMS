using ESLab.SPMS.FinishProductFormulas.Dtos;
using System.Collections.Generic;

namespace ESLab.SPMS.FinishProducts.Dtos
{
    public class GetFinishProductDetailsByIdOutput
    {
        public FinishProductDto FinishProduct { get; set; }
        public List<FinishProductFormulaDto> FinishProductFormulaItems { get; set; }
    }
}
