using Abp.Application.Services;
using AutoMapper;
using ESLab.SPMS.Brands.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace ESLab.SPMS.Brands
{
    public class BrandAppService : ApplicationService, IBrandAppService
    {
        readonly IBrandRepository _brandRepository;

        public BrandAppService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public void CreateBrand(CreateBrandInput input)
        {
            var brand = new Brand { BrandCode = input.BrandCode, BrandName = input.BrandName, BrandType= input.BrandType, CreatorUserId = input.CreatorUserId };
            _brandRepository.Insert(brand);
        }

        public GetAllBrandsOutput GetAllBrands()
        {
            var brands = _brandRepository.GetAll().OrderBy(b => b.CreationTime);

            return new GetAllBrandsOutput
            {
                Brands = Mapper.Map<List<BrandDto>>(brands)
            };
        }

        public void UpdateBrand(UpdateBrandInput input)
        {
            var brand = _brandRepository.Get(input.Id);

            brand.BrandCode = input.BrandCode;
            brand.BrandName = input.BrandName;
            brand.BrandType = input.BrandType;

            _brandRepository.Update(brand);
        }

        public BrandDto GetByCode(GetByCodeInput input)
        {
            //string Code = "hp";
            var brand = _brandRepository.GetAll().FirstOrDefault(b => b.BrandCode == input.Code);

            return Mapper.Map<BrandDto>(brand);

        }

        public GetAllBrandsOutput GetBrandsByBrandType(GetBrandsByBrandTypeInput input)
        {
            var brands = _brandRepository.GetAll().Where(b => b.BrandType == input.BrandType);

            return new GetAllBrandsOutput
            {
                Brands = Mapper.Map<List<BrandDto>>(brands)
            };
        }
    }
}