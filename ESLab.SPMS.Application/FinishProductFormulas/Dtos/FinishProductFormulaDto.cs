using Abp.Application.Services.Dto;
using System;

namespace ESLab.SPMS.FinishProductFormulas.Dtos
{
    public class FinishProductFormulaDto : EntityDto
    {       
        public int FinishProductId { get; set; }        
        public int RawMaterialId { get; set; }        
        public float Percentage { get; set; }
        public string FullProductName { get; set; }
        public long CreatorUserId { get; set; }
        public virtual DateTime CreationTime { get; set; }
    }
}
