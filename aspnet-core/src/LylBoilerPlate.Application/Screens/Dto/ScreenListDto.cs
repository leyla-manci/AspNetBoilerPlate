using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;

namespace LylBoilerPlate.Screens.Dto
{
    public class ScreenListDto : EntityDto, IHasCreationTime
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
