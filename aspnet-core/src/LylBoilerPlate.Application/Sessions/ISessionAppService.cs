using System.Threading.Tasks;
using Abp.Application.Services;
using LylBoilerPlate.Sessions.Dto;

namespace LylBoilerPlate.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
