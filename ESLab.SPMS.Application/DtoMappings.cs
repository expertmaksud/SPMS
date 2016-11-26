using AutoMapper;
using ESLab.SPMS.Brands;
using ESLab.SPMS.Brands.Dtos;
using ESLab.SPMS.ProductGrades;
using ESLab.SPMS.ProductGrades.Dtos;
using ESLab.SPMS.Zones;
using ESLab.SPMS.Zones.Dtos;
using ESLab.SPMS.ProductCategories;
using ESLab.SPMS.ProductCategories.Dtos;
using ESLab.SPMS.Freights;
using ESLab.SPMS.Freights.Dtos;
using ESLab.SPMS.Vendors;
using ESLab.SPMS.Vendors.Dtos;
using ESLab.SPMS.ProductUnits;
using ESLab.SPMS.ProductUnits.Dtos;
using ESLab.SPMS.RawMaterialTypes;
using ESLab.SPMS.RawMaterialTypes.Dtos;
using ESLab.SPMS.ProductApis;
using ESLab.SPMS.ProductApis.Dtos;
using ESLab.SPMS.Distributors;
using ESLab.SPMS.Distributors.Dtos;
using ESLab.SPMS.RawMaterials;
using ESLab.SPMS.RawMaterials.Dtos;
using ESLab.SPMS.Warehouses;
using ESLab.SPMS.Warehouses.Dtos;
using ESLab.SPMS.FinishProducts;
using ESLab.SPMS.FinishProducts.Dtos;
using ESLab.SPMS.FinishProductFormulas;
using ESLab.SPMS.FinishProductFormulas.Dtos;

namespace ESLab.SPMS
{
    static class DtoMappings
    {
        public static void Map()
        {
            Mapper.CreateMap<Brand, BrandDto>();
            Mapper.CreateMap<Zone, ZoneDto>();
            Mapper.CreateMap<ProductGrade, ProductGradeDto>();
            Mapper.CreateMap<ProductCategory, ProductCategoryDto>();
            Mapper.CreateMap<Freight, FreightDto>();
            Mapper.CreateMap<Vendor, VendorDto>();
            Mapper.CreateMap<ProductUnit, ProductUnitDto>();
            Mapper.CreateMap<RawMaterialType, RawMaterialTypeDto>();
            Mapper.CreateMap<ProductApi, ProductApiDto>();
            Mapper.CreateMap<Distributor, DistributorDto>();
            Mapper.CreateMap<Warehouse, WarehouseDto>();
            Mapper.CreateMap<FinishProduct, FinishProductDto>()
                .ForMember(src => src.BrandName, opt => opt.MapFrom(b => b.Brand.BrandName))
                .ForMember(src => src.ProductGradeName, opt => opt.MapFrom(p => p.ProductGrade.GradeName))
                .ForMember(src => src.ProductApiName, opt => opt.MapFrom(p => p.ProductApi.ApiName))
                .ForMember(src => src.ProductCategoryName, opt => opt.MapFrom(p => p.ProductCategory.CategoryName))
                .ForMember(src => src.ProductUnitName, opt => opt.MapFrom(p => p.ProductUnit.UnitName))
                .ForMember(src => src.FullProductName, opt => opt.MapFrom(p => p.Brand.BrandName + "-" + p.ProductName + "-" + p.ProductGrade.GradeCode + "-" + p.ProductApi.ApiCode));

            Mapper.CreateMap<FinishProductFormula, FinishProductFormulaDto>()
                .ForMember(src => src.FullProductName, opt => opt.MapFrom(p => p.RawMaterial.ProductName + "-" + p.RawMaterial.Model + "-" + p.RawMaterial.Size + "-" + p.RawMaterial.Color));


            Mapper.CreateMap<RawMaterial, RawMaterialDto>()
               .ForMember(src => src.BrandName, opt => opt.MapFrom(b => b.Brand.BrandName))
               .ForMember(src => src.RawMaterialTypeName, opt => opt.MapFrom(r => r.RawMaterialType.RawMaterialTypeName))
               .ForMember(src => src.UnitName, opt => opt.MapFrom(p => p.ProductUnit.UnitName))
               .ForMember(src => src.FullProductName, opt => opt.MapFrom(p => p.RawMaterialType.RawMaterialTypeCode + "-" + p.Brand.BrandName + "-" + p.ProductName + "-" + p.Origin));
        }

    }
}
