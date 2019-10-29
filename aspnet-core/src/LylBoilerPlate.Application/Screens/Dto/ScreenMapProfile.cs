using AutoMapper;
using LylBoilerPlate.Models.Screens;
using System;
using System.Collections.Generic;
using System.Text;

namespace LylBoilerPlate.Screens.Dto
{
    class ScreenMapProfile : Profile
    {
        public ScreenMapProfile()
        {

            CreateMap<CreateScreenInput, Screen>();
            CreateMap<Screen, GetScreenOutput>();         
            CreateMap<UpdateScreenInput, Screen>();
            CreateMap<Screen, ScreenListDto>();
            
        }
    }
}
