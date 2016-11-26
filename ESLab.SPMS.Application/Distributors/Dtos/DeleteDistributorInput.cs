using Abp.Application.Services.Dto;

namespace ESLab.SPMS.Distributors.Dtos
{
    public class DeleteDistributorInput : IInputDto
    {
        public int Id { get; set; }
    }
}
