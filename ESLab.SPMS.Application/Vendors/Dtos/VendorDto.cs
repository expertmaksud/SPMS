using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace ESLab.SPMS.Vendors.Dtos
{
    public class VendorDto : EntityDto  
    {
        public string VendorCode { get; set; }
        public string VendorName { get; set; }
        public string VendorAddress { get; set; }
        public string VendorContactPerson { get; set; }
        public string VendorContactNumber { get; set; }
        public string VendorContactEmail { get; set; }
        public string VendorWebsite { get; set; }
        public string VendorFax { get; set; }
        public string VendorBankDetails { get; set; }
        
        public long CreatorUserId { get; set; }
        public virtual DateTime CreationTime { get; set; }
    }
}
