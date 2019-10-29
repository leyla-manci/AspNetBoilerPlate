using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LylBoilerPlate.Models.Screens
{

    public class Screen : FullAuditedEntity
    {
        [Required]
        [Display(Name = " Screen Name")]
        [StringLength(100, ErrorMessage = " Maximum length is 100")]
        public string Name { get; set; }



    }
}
