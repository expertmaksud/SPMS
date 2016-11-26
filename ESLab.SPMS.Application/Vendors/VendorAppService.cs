using Abp.Application.Services;
using AutoMapper;
using ESLab.SPMS.Vendors.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace ESLab.SPMS.Vendors
{
    public class VendorAppService : ApplicationService, IVendorAppService 
    {
        readonly IVendorRepository _vendorRepository;
        
        public VendorAppService(IVendorRepository vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }

        public void CreateVendor(CreateVendorInput input)
        {
            var vendor = new Vendor
            {
                VendorCode = input.VendorCode,
                VendorName = input.VendorName,
                VendorAddress = input.VendorAddress,
                VendorContactEmail = input.VendorContactEmail,
                VendorContactNumber = input.VendorContactNumber,
                VendorContactPerson = input.VendorContactPerson,
                VendorFax = input.VendorFax,
                VendorWebsite = input.VendorWebsite,
                VendorBankDetails = input.VendorBankDetails,
                CreatorUserId = input.CreatorUserId
            };
            _vendorRepository.Insert(vendor);
        }

        public GetAllVendorsOutput GetAllVendors()
        {
            var vendors = _vendorRepository.GetAll().OrderBy(b => b.CreationTime);
            return new GetAllVendorsOutput
            {
                Vendors = Mapper.Map<List<VendorDto>>(vendors)
            };
        }

        public void UpdateVendor(UpdateVendorInput input)
        {
            var vendor = _vendorRepository.Get(input.Id);

            vendor.VendorCode = input.VendorCode;
            vendor.VendorName = input.VendorName;
            vendor.VendorAddress = input.VendorAddress;
            vendor.VendorContactEmail = input.VendorContactEmail;
            vendor.VendorContactNumber = input.VendorContactNumber;
            vendor.VendorFax = input.VendorFax;
            vendor.VendorWebsite = input.VendorWebsite;
            vendor.VendorContactPerson = input.VendorContactPerson;
            vendor.VendorBankDetails = input.VendorBankDetails;

            _vendorRepository.Update(vendor);
        }

        public VendorDto GetByCode(GetByCodeInput input)
        {
            var vendor = _vendorRepository.GetAll().FirstOrDefault(b => b.VendorCode == input.code);

            return Mapper.Map<VendorDto>(vendor);
        }


    }
}
