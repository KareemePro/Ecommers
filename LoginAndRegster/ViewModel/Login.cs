
namespace LoginAndRegster.ViewModel
{
    public class Login
    {
        [Required(ErrorMessage = "Please enter your email address")]
        public string Email { get; set; } = string.Empty;


        [Required(ErrorMessage = "Please enter a password")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
