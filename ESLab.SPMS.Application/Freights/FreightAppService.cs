using Abp.Application.Services;
using AutoMapper;
using ESLab.SPMS.Freights.Dtos;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ESLab.SPMS.Freights
{
    public class FreightAppService : ApplicationService, IFreightAppService
    {
        readonly IFreightRepository _FreightRepository;

        public FreightAppService(IFreightRepository FreightRepository)
        {
            _FreightRepository = FreightRepository;
        }

        public void CreateFreight(CreateFreightInput input)
        {
            var freight = new Freight { FreightCode = input.FreightCode, FreightName = input.FreightName, CreatorUserId = input.CreatorUserId };
            _FreightRepository.Insert(freight);
        }

        public void DeleteFreight(DeleteFreightInput input)
        {
            var freight = _FreightRepository.Get(input.Id);
            freight.IsDeleted = true;
            _FreightRepository.Delete(freight);
        }

        public GetAllFreightsOutput GetAllFreights()
        {
            var freight = _FreightRepository.GetAll().OrderBy(b => b.CreationTime);
            return new GetAllFreightsOutput
            {
                Freights = Mapper.Map<List<FreightDto>>(freight)
            };
        }

        public void UpdateFreight(UpdateFreightInput input)
        {
            var freight = _FreightRepository.Get(input.Id);

            freight.FreightCode = input.FreightCode;
            freight.FreightName = input.FreightName;

            _FreightRepository.Update(freight);
        }
    }
}
