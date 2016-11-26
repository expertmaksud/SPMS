using Abp.Application.Services;
using AutoMapper;
using ESLab.SPMS.ProductGrades.Dtos;
using System.Collections.Generic;
using System.Linq;
using System;
using ESLab.SPMS.ProductGrades;

namespace ESLab.SPMS.ProductGrades
{
    public class ProductGradeAppService : ApplicationService, IProductGradeAppService
    {
        readonly IProductGradeRepository  _productGradeRepository;

        public ProductGradeAppService(IProductGradeRepository productGradeRepository)
        {
            _productGradeRepository = productGradeRepository;
        }

        public void CreateProductGrade(CreateProductGradeInput input)
        {
            var produtGrade = new ProductGrade { GradeCode = input.GradeCode, GradeName = input.GradeName, CreatorUserId = input.CreatorUserId };
            _productGradeRepository.Insert(produtGrade);
        }

        public GetAllProductGradesOutput GetAllProductGrades()
        {
            var ProductGrades = _productGradeRepository.GetAll().OrderBy(b => b.CreationTime);

            return new GetAllProductGradesOutput
            {
                ProductGrades = Mapper.Map<List<ProductGradeDto>>(ProductGrades)
            };
        }

        public void UpdateProductGrade(UpdateProductGradeInput input)
        {
            var productGrade = _productGradeRepository.Get(input.Id);

            productGrade.GradeCode = input.GradeCode;
            productGrade.GradeName = input.GradeName;

            _productGradeRepository.Update(productGrade);
        }

        public void DeleteProductGrade(DeleteProductGradeInput input)
        {
            var productGrade = _productGradeRepository.Get(input.Id);

            productGrade.IsDeleted = true;


            _productGradeRepository.Delete(productGrade);
        }

       
    }
}
