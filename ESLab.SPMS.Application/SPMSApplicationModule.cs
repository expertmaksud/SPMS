using Abp.AutoMapper;
using Abp.Modules;
using System.Reflection;
using Abp.Zero;

namespace ESLab.SPMS
{
    [DependsOn(typeof(SPMSCoreModule), typeof(AbpAutoMapperModule))]
    public class SPMSApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<SPMSAuthorizationProvider>();
            
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            DtoMappings.Map();
        }
    }
}