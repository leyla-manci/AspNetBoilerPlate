using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using LylBoilerPlate.Roles.Dto;
using LylBoilerPlate.Users.Dto;

namespace LylBoilerPlate.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
