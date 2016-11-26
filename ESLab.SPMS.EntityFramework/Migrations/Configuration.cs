using System.Data.Entity.Migrations;
using ESLab.SPMS.Migrations.SeedData;
using EntityFramework.DynamicFilters;

namespace ESLab.SPMS.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SPMS.EntityFramework.SPMSDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SPMS";
        }

        protected override void Seed(SPMS.EntityFramework.SPMSDbContext context)
        {
            context.DisableAllFilters();
            new InitialDataBuilder(context).Build();
        }
    }
}
