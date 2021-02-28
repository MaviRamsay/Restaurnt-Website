using Restaurant_Website.Domain.Core;

namespace Restaurant_Website.Services.DataTransferObjects
{
    public class LanguageDTO
    {
        public string Code { get; set; }
        public string Description { get; set; }

        public LanguageDTO(Language language)
        {
            this.Code = language.Code;
            this.Description = language.Description; 
        }
    }
}
