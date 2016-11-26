using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESLab.SPMS.Zones;
using Abp.EntityFramework;

namespace ESLab.SPMS.EntityFramework.Repositories
{
   public class ZoneRepository : SPMSRepositoryBase<Zone>, IZoneRepository
    {
        public ZoneRepository(IDbContextProvider<SPMSDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}
