using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace LylBoilerPlate.Screens.Dto
{
    class PagedScreenResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
