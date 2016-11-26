using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESLab.SPMS.Brands.Dtos
{
   public class GetBrandsByBrandTypeInput : IInputDto
    {
        public MaterialType BrandType { get; set; }
    }
}
