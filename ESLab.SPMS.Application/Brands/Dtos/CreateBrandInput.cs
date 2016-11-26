using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESLab.SPMS.Brands.Dtos
{
    public class CreateBrandInput : IInputDto
    {
        [Required]
        public string BrandCode { get; set; }

        [Required]
        public string BrandName { get; set; }

        [Required]
        public MaterialType BrandType { get; set; }

        public long CreatorUserId { get; set; }

    }
}
