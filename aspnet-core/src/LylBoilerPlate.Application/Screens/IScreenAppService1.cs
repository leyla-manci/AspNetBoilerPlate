using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using LylBoilerPlate.Screens.Dto;

namespace LylBoilerPlate.Screens
{
    public interface IScreenAppService1
    {
        Task Create(CreateScreenInput input);
        void Delete(DeleteScreenInput input);
        GetScreenOutput GetScreenById(GetScreenInput input);
        Task<ScreenEditDto> GetScreenForEdit(EntityDto input);
        Task<ListResultDto<GetScreenOutput>> GetScreensAsync(GetScreenInput input);
        IEnumerable<GetScreenOutput> ListAll();
        void Update(UpdateScreenInput input);
    }
}