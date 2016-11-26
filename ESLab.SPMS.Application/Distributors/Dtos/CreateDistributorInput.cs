using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace ESLab.SPMS.Distributors.Dtos
{
    public class CreateDistributorInput : IInputDto
    {
        [Required]
        public string DistributorCode { get; set; }

        [Required]
        public string DistributorName { get; set; }

        public string DistributorAddress { get; set; }
        public string DistributorCity { get; set; }
        public string DistributorCountry { get; set; }
        public string DistributorContactPerson { get; set; }
        public string DistributorJobTitle { get; set; }
        public string DistributorMobileNumber { get; set; }
        public string DistributorContactEmail { get; set; }
        public string DistributorHomePhone { get; set; }
        public string DistributorFaxNumber { get; set; }

        public long CreatorUserId { get; set; }
    }
}
