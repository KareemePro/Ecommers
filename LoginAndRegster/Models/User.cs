using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginAndRegster.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please enter your first name")]
        [MinLength(3, ErrorMessage = "A name must be at least 3 letters")]
        [MaxLength(15, ErrorMessage = "A name must be not more than 15 letters")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please enter your first name in English letters")]
        public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter your last name")]
        [MinLength(3,ErrorMessage = "A name must be at least 3 letters")]
        [MaxLength(15, ErrorMessage ="A name must be not more than 15 letters")]
        [RegularExpression(@"^[a-zA-Z]+$" , ErrorMessage = "Please enter your last name in English letters")]
        public string LastName { get; set; } = string.Empty;


        [Required(ErrorMessage="Please enter your email address")]
        [EmailAddress(ErrorMessage ="Please enter a valid email address")]
        [RegularExpression(@"\b\S+@(gmail|hotmail)\.com\b" , ErrorMessage= "At the moment we only accept Gmail, Hotmail")]
        public string Email { get; set; } = string.Empty;


        [Required(ErrorMessage = "Please enter a password")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$",
         ErrorMessage = "Password must be at least 6 characters long and contain at least 1 letter, 1 number")]
        public string Password { get; set; } =string.Empty;


        [Required(ErrorMessage = "Please enter a confirm password")]
        [Compare("Password", ErrorMessage = "Password not mutched")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [NotMapped]
        public string ConfirmPassword { get; set; } = string.Empty;

        public DateTime CreateDate { get; set; } = DateTime.Now;

       
        
    }
}
