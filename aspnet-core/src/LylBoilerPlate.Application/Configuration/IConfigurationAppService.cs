using System.Threading.Tasks;
using LylBoilerPlate.Configuration.Dto;

namespace LylBoilerPlate.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
