using Abp.Application.Services;
using ESLab.SPMS.Vendors.Dtos;
using System.Web.Http;

namespace ESLab.SPMS.Vendors
{
    public interface IVendorAppService : IApplicationService
    {
        [HttpPost]
        void CreateVendor(CreateVendorInput input);

        [HttpGet]
        GetAllVendorsOutput GetAllVendors();

        [HttpPost]
        void UpdateVendor(UpdateVendorInput input);

      
        VendorDto GetByCode(GetByCodeInput input);
    }
}
