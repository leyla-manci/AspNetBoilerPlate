using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace LylBoilerPlate.Controllers
{
    public abstract class LylBoilerPlateControllerBase: AbpController
    {
        protected LylBoilerPlateControllerBase()
        {
            LocalizationSourceName = LylBoilerPlateConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
