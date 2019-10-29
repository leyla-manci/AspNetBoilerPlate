using System.ComponentModel.DataAnnotations;

namespace LylBoilerPlate.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}