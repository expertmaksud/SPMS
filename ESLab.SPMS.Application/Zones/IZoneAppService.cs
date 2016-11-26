using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using ESLab.SPMS.Zones.Dtos;

namespace ESLab.SPMS.Zones
{
   public interface IZoneAppService : IApplicationService
    {
        void CreateZone(CreateZoneInput input);
        GetAllZonesOutput GetAllZones();
        void UpdateZone(UpdateZoneInput input);
        void DeleteZone(DeleteZoneInput input);
    }
}
