using Abp.Application.Services;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using ESLab.SPMS.RawMaterials.Dtos;
using System;

namespace ESLab.SPMS.RawMaterials
{
    public class RawMaterialAppService : ApplicationService, IRawMaterialAppService
    {

        readonly IRawMaterialRepository _RawMaterialRepository;

        public RawMaterialAppService(IRawMaterialRepository RawMaterialRepository)
        {
            _RawMaterialRepository = RawMaterialRepository;
        }

        public void CreateRawMaterial(CreateRawMaterialInput input)
        {
            var rawmaterial = new RawMaterial {
                RawMaterialTypeId = input.RawMaterialTypeId,
                BrandId = input.BrandId,
                ProductName = input.ProductName,
                Model = input.Model,
                Size = input.Size,
                Color= input.Color,
                Origin = input.Origin,
                ProductUnitId = input.ProductUnitId,
                ReOrderPoint=input.ReOrderPoint,
                CreatorUserId = input.CreatorUserId
            };
            _RawMaterialRepository.Insert(rawmaterial);
        }

        public void DeleteRawMaterial(DeleteRawMaterialInput input)
        {
            var rawmaterial = _RawMaterialRepository.Get(input.Id);
            rawmaterial.IsDeleted = true;
            _RawMaterialRepository.Delete(rawmaterial);
        }

        public GetAllRawMaterialsOutput GetAllRawMaterials()
        {
            var rawMaterials = _RawMaterialRepository.GetAll().OrderBy(b => b.CreationTime);

            return new GetAllRawMaterialsOutput
            {
                RawMaterials = Mapper.Map<List<RawMaterialDto>>(rawMaterials)
            };
        }

        public void UpdateRawMaterial(UpdateRawMaterialInput input)
        {
            var rawmaterial = _RawMaterialRepository.Get(input.Id);

            rawmaterial.RawMaterialTypeId = input.RawMaterialTypeId;
            rawmaterial.BrandId = input.BrandId;
            rawmaterial.ProductName = input.ProductName;
            rawmaterial.Model = input.Model;
            rawmaterial.Size = input.Size;
            rawmaterial.Color = input.Color;
            rawmaterial.Origin = input.Origin;
            rawmaterial.ProductUnitId = input.ProductUnitId;
            rawmaterial.ReOrderPoint = input.ReOrderPoint;
            
            _RawMaterialRepository.Update(rawmaterial);
        }
    }
}
