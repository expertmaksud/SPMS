using System.Reflection;
using Abp.Application.Services;
using Abp.Modules;
using Abp.WebApi;
using Abp.WebApi.Controllers.Dynamic.Builders;
using ESLab.SPMS.Procurement;
using ESLab.SPMS.Inventory;
using ESLab.SPMS.Sales;
using ESLab.SPMS.Production;

namespace ESLab.SPMS
{
    [DependsOn(typeof(AbpWebApiModule), typeof(SPMSApplicationModule), typeof(ProcurementAppModule),
        typeof(InventoryAppModule), typeof(SalesAppModule))]
    public class SPMSWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(SPMSApplicationModule).Assembly, "app")
                .Build();
            DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(ProcurementAppModule).Assembly, "procurement")
                .Build();
            DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(InventoryAppModule).Assembly, "inventory")
                .Build();
            DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(SalesAppModule).Assembly, "sales")
                .Build();

            DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(ProductionAppModule).Assembly, "production")
                .Build();
        }
    }
}
