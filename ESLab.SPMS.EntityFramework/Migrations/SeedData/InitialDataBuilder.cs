using ESLab.SPMS.EntityFramework;

namespace ESLab.SPMS.Migrations.SeedData
{
    public class InitialDataBuilder
    {
        private readonly SPMSDbContext _context;

        public InitialDataBuilder(SPMSDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            new DefaultTenantRoleAndUserBuilder(_context).Build();
        }
    }
}
