using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using LylBoilerPlate.Configuration.Dto;

namespace LylBoilerPlate.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : LylBoilerPlateAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
