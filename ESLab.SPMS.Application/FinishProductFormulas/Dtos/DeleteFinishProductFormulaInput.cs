using Abp.Application.Services.Dto;

namespace ESLab.SPMS.FinishProductFormulas.Dtos
{
    public class DeleteFinishProductFormulaInput : IInputDto
    {
        public int Id { get; set; }
    }
}
