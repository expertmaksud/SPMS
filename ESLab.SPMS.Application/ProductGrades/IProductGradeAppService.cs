using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using ESLab.SPMS.ProductGrades.Dtos;

namespace ESLab.SPMS.ProductGrades
{
    public interface IProductGradeAppService : IApplicationService
    {
        void CreateProductGrade(CreateProductGradeInput input);
        GetAllProductGradesOutput GetAllProductGrades();
        void UpdateProductGrade(UpdateProductGradeInput input);
        void DeleteProductGrade(DeleteProductGradeInput input);
    }
}