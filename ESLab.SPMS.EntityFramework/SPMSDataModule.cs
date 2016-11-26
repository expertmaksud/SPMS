using Abp.Modules;
using Abp.Zero.EntityFramework;
using ESLab.SPMS.Inventory;
using ESLab.SPMS.Procurement;
using System.Reflection;

namespace ESLab.SPMS
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(SPMSCoreModule), typeof(ProcurementDomainModule),
        typeof(InventoryDomainModule))]
    public class SPMSDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}