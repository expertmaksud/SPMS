using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESLab.SPMS.ProductGrades.Dtos
{
    public class DeleteProductGradeInput : IInputDto
    {
        public int Id { get; set; }
    }
}
