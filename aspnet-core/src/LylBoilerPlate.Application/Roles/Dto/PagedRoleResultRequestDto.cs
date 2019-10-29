using Abp.Application.Services.Dto;

namespace LylBoilerPlate.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

