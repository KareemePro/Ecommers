using LoginAndRegster.Attributes;
using LoginAndRegster.Setting;

namespace LoginAndRegster.ViewModel
{
    public class EditProductViewModel:ProductViewModel
    {
        public int Id { get; set; }
        public string? CurrentName { get; set; }
        
        [AllowedExtensionAttribuet(allowedExtension: FileSetting.AllowedExtensions)]
        [MaxFileSize(FileSetting.MaxSizeInByets)]
        public IFormFile? Image { get; set; } = default! ;
    }
}
