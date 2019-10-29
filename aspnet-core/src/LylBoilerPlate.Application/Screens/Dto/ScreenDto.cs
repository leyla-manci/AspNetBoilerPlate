using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LylBoilerPlate.Screens.Dto
{
    class ScreenDto : EntityDto<int>
    {
        [Required]
        [Display(Name = " Screen Name")]
        [StringLength(100, ErrorMessage = " Maximum length is 100")]
        public string Name { get; set; }
    }
}
