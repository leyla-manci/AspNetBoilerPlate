using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LylBoilerPlate.Authorization;
using LylBoilerPlate.Models.Screens;
using LylBoilerPlate.Screens.Dto;
using System.Collections.Generic;

namespace LylBoilerPlate
{
    [DependsOn(
        typeof(LylBoilerPlateCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class LylBoilerPlateApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<LylBoilerPlateAuthorizationProvider>();
        


        }

        public override void Initialize()
        {
            var thisAssembly = typeof(LylBoilerPlateApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
