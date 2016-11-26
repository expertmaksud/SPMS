using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESLab.SPMS.ProductGrades.Dtos
{
    public class CreateProductGradeInput : IInputDto
    {
        [Required]
        public string GradeCode { get; set; }

        [Required]
        public string GradeName { get; set; }
        public long CreatorUserId { get; set; }

        public override string ToString()
        {
            return string.Format("[CreateProductGradeInput > Code = {0}, Name ={1}", GradeCode, GradeName);
        }
    }
}
