using Abp.Application.Services;
using Abp.Application.Services.Dto;
using LylBoilerPlate.MultiTenancy.Dto;

namespace LylBoilerPlate.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

