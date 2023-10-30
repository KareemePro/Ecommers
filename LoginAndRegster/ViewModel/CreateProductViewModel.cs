using LoginAndRegster.Attributes;
using LoginAndRegster.Setting;

namespace LoginAndRegster.ViewModel
{
    public class CreateProductViewModel : ProductViewModel
    {


        [AllowedExtensionAttribuet(allowedExtension: FileSetting.AllowedExtensions)]
        [MaxFileSize(FileSetting.MaxSizeInByets)]
        public IFormFile Image { get; set; } = default!;
    }
}
