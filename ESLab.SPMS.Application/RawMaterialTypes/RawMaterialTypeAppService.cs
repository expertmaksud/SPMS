using Abp.Application.Services;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using ESLab.SPMS.RawMaterialTypes.Dtos;

namespace ESLab.SPMS.RawMaterialTypes
{
    public class RawMaterialTypeAppService : ApplicationService, IRawMaterialTypeAppService
    {

        readonly IRawMaterialTypeRepository _RawMaterialTypeRepository;

        public RawMaterialTypeAppService(IRawMaterialTypeRepository RawMaterialTypeRepository)
        {
            _RawMaterialTypeRepository = RawMaterialTypeRepository;
        }

        public void CreateRawMaterialType(CreateRawMaterialTypeInput input)
        {
            var rawmaterialtype = new RawMaterialType { RawMaterialTypeCode = input.RawMaterialTypeCode, RawMaterialTypeName = input.RawMaterialTypeName, CreatorUserId = input.CreatorUserId };
            _RawMaterialTypeRepository.Insert(rawmaterialtype);
        }

        public void DeleteRawMaterialType(DeleteRawMaterialTypeInput input)
        {
            var rawmaterialtype = _RawMaterialTypeRepository.Get(input.Id);
            rawmaterialtype.IsDeleted = true;
            _RawMaterialTypeRepository.Delete(rawmaterialtype);
        }

        public GetAllRawMaterialTypesOutput GetAllRawMaterialTypes()
        {
            var rawmaterialtype = _RawMaterialTypeRepository.GetAll().OrderBy(b => b.CreationTime);

            return new GetAllRawMaterialTypesOutput
            {
                RawMaterialTypes = Mapper.Map<List<RawMaterialTypeDto>>(rawmaterialtype)
            };
        }

        public void UpdateRawMaterialType(UpdateRawMaterialTypeInput input)
        {
            var rawmaterialtype = _RawMaterialTypeRepository.Get(input.Id);

            rawmaterialtype.RawMaterialTypeCode = input.RawMaterialTypeCode;
            rawmaterialtype.RawMaterialTypeName = input.RawMaterialTypeName;

            _RawMaterialTypeRepository.Update(rawmaterialtype);
        }
    }
}
