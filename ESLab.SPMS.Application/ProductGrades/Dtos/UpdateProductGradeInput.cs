using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESLab.SPMS.ProductGrades.Dtos
{
    public class UpdateProductGradeInput : IInputDto
    {
        public int Id { get; set; }
        [Required]
        public string GradeCode { get; set; }
        [Required]
        public string GradeName { get; set; }

    }
}