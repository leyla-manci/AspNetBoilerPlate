using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AutoMapper;
using LylBoilerPlate.Models.Screens;
using LylBoilerPlate.Screens.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LylBoilerPlate.Screens
{
    public class ScreenAppService : ApplicationService, IScreenAppService
    {
        private readonly IScreenManager _screenManager;

        public ScreenAppService(IScreenManager screenManager)
        {
             _screenManager = screenManager;
        }
        public async Task Create(CreateScreenInput input)
        {
            Screen screen = ObjectMapper.Map<Screen>(input);
            await _screenManager.Create(screen);
        }

        public void Delete(DeleteScreenInput input)
        {
            _screenManager.Delete(input.Id);
        }



        public async Task<ScreenEditDto> GetScreenForEdit(EntityDto input)
        {
            
            Screen screen = await _screenManager.GetScreenByIdAsync(input.Id);
            ScreenEditDto screenEditDto = new ScreenEditDto();
            screenEditDto.screen = screen;




            return screenEditDto;
        }


        public async Task<ListResultDto<GetScreenOutput>> GetScreensAsync(string Keyword)
        {
            var screens = await _screenManager.GetScreens(Keyword);

            return new ListResultDto<GetScreenOutput>(ObjectMapper.Map<List<GetScreenOutput>>(screens));

        }

        public GetScreenOutput GetScreenById(GetScreenInput input)
        {
            var screen = _screenManager.GetScreenByID(input.Id);
            GetScreenOutput output = ObjectMapper.Map<GetScreenOutput>(screen);
            return output;
        }

        public IEnumerable<GetScreenOutput> ListAll()
        {
            var getAll = _screenManager.GetAllList().ToList();
            List<GetScreenOutput> output = ObjectMapper.Map <List<GetScreenOutput>>(getAll);
            return output;
        }

        public void Update(UpdateScreenInput input)
        {
            Screen output = ObjectMapper.Map<Screen>(input);
            _screenManager.Update(output);
        }
    }
}
