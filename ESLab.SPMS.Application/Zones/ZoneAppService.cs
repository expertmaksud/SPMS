using Abp.Application.Services;
using AutoMapper;
using ESLab.SPMS.Zones.Dtos;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ESLab.SPMS.Zones
{
    public class ZoneAppService : ApplicationService, IZoneAppService
    {
        readonly IZoneRepository _zoneRepository;

        public ZoneAppService(IZoneRepository zoneRepository)
        {
            _zoneRepository = zoneRepository;
        }

        public void CreateZone(CreateZoneInput input)
        {
            var zone = new Zone { ZoneCode = input.ZoneCode, ZoneName = input.ZoneName, CreatorUserId = input.CreatorUserId };
            _zoneRepository.Insert(zone);
        }

        public void DeleteZone(DeleteZoneInput input)
        {
            var zone = _zoneRepository.Get(input.Id);
            _zoneRepository.Delete(zone);
        }

        public GetAllZonesOutput GetAllZones()
        {
            var zones = _zoneRepository.GetAll().OrderBy(b => b.CreationTime);

            return new GetAllZonesOutput
            {
                Zones = Mapper.Map<List<ZoneDto>>(zones)
            };
        }

        public void UpdateZone(UpdateZoneInput input)
        {
            var zone = _zoneRepository.Get(input.Id);

            zone.ZoneCode = input.ZoneCode;
            zone.ZoneName = input.ZoneName;

            _zoneRepository.Update(zone);
        }
    }
}