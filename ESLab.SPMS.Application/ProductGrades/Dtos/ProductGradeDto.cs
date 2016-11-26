using Abp.Application.Services.Dto;
using System;

namespace ESLab.SPMS.ProductGrades.Dtos
{
    public class ProductGradeDto : EntityDto
    {
        public string GradeCode { get; set; }
        public string GradeName { get; set; }
        public long CreatorUserId { get; set; }
        public virtual DateTime CreationTime { get; set; }
    }
}
