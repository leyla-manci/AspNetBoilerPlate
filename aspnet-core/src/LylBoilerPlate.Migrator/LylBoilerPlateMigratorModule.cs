using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LylBoilerPlate.Configuration;
using LylBoilerPlate.EntityFrameworkCore;
using LylBoilerPlate.Migrator.DependencyInjection;

namespace LylBoilerPlate.Migrator
{
    [DependsOn(typeof(LylBoilerPlateEntityFrameworkModule))]
    public class LylBoilerPlateMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public LylBoilerPlateMigratorModule(LylBoilerPlateEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(LylBoilerPlateMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                LylBoilerPlateConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LylBoilerPlateMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
