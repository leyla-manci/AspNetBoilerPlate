using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LylBoilerPlate.Configuration;

namespace LylBoilerPlate.Web.Host.Startup
{
    [DependsOn(
       typeof(LylBoilerPlateWebCoreModule))]
    public class LylBoilerPlateWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public LylBoilerPlateWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LylBoilerPlateWebHostModule).GetAssembly());
        }
    }
}
