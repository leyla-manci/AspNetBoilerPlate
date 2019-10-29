using Abp.Application.Services;
using Abp.Application.Services.Dto;
using LylBoilerPlate.Screens.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LylBoilerPlate.Screens
{
    public interface IScreenAppService :IApplicationService
    {
        IEnumerable<GetScreenOutput> ListAll();
        Task Create(CreateScreenInput input);
        void Update(UpdateScreenInput input);
        void Delete(DeleteScreenInput input);
        GetScreenOutput GetScreenById(GetScreenInput input);
       Task<ListResultDto<GetScreenOutput>> GetScreensAsync(string Keyword);
        Task<ScreenEditDto> GetScreenForEdit(EntityDto input);
    }
}
