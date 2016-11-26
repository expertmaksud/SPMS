using Abp.Application.Services;
using AutoMapper;
using ESLab.SPMS.Freights.Dtos;
using System.Collections.Generic;
using System.Linq;
using ESLab.SPMS.Distributors.Dtos;
using System;

namespace ESLab.SPMS.Distributors
{
    public class DistributorAppService : ApplicationService, IDistributorAppService
    {
        readonly IDistributorRepository _DistributorRepository;

        public DistributorAppService(IDistributorRepository DistributorRepository)
        {
            _DistributorRepository = DistributorRepository;
        }

        public void CreateDistributor(CreateDistributorInput input)
        {
            var distributor = new Distributor {
                DistributorCode = input.DistributorCode,
                DistributorName = input.DistributorName,
                DistributorAddress = input.DistributorAddress,
                DistributorCity = input.DistributorCity,
                DistributorCountry = input.DistributorCountry,
                DistributorContactPerson = input.DistributorContactPerson,
                DistributorJobTitle = input.DistributorJobTitle,
                DistributorMobileNumber = input.DistributorMobileNumber,
                DistributorContactEmail = input.DistributorContactEmail,
                DistributorHomePhone = input.DistributorHomePhone,
                DistributorFaxNumber = input.DistributorFaxNumber,
                CreatorUserId = input.CreatorUserId
            };
            _DistributorRepository.Insert(distributor);
        }

        public void DeleteDistributor(DeleteDistributorInput input)
        {
            var distributor = _DistributorRepository.Get(input.Id);
            distributor.IsDeleted = true;
            _DistributorRepository.Delete(distributor);
        }

        public GetAllDistributorsOutput GetAllDistributors()
        {
            var distributor = _DistributorRepository.GetAll().OrderBy(b => b.CreationTime);
            return new GetAllDistributorsOutput
            {
                Distributors = Mapper.Map<List<DistributorDto>>(distributor)
            };
        }

        public void UpdateDistributor(UpdateDistributorInput input)
        {
            var distributor = _DistributorRepository.Get(input.Id);

            distributor.DistributorCode = input.DistributorCode;
            distributor.DistributorName = input.DistributorName;
            distributor.DistributorAddress = input.DistributorAddress;
            distributor.DistributorCity = input.DistributorCity;
            distributor.DistributorCountry = input.DistributorCountry;
            distributor.DistributorContactPerson = input.DistributorContactPerson;
            distributor.DistributorJobTitle = input.DistributorJobTitle;
            distributor.DistributorMobileNumber = input.DistributorMobileNumber;
            distributor.DistributorContactEmail = input.DistributorContactEmail;
            distributor.DistributorHomePhone = input.DistributorHomePhone;
            distributor.DistributorFaxNumber = input.DistributorFaxNumber;

            _DistributorRepository.Update(distributor);
        }
    }
}
