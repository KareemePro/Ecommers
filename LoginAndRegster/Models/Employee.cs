using System.ComponentModel.DataAnnotations.Schema;

namespace LoginAndRegster.Models
{
    public class Employee : User
    {


        [Required(ErrorMessage = "Please enter the employee Middle Name date")]
        [MinLength(3, ErrorMessage = "A name must be at least 3 letters")]
        [MaxLength(15, ErrorMessage = "A name must be not more than 15 letters")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please enter your first name in English letters")]
        public string MiddleName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your phone number")]
        [MinLength(11, ErrorMessage = "A phone number should contain 11 digits")]
        [MaxLength(11, ErrorMessage = "A phone number should contain 11 digits")]
        [RegularExpression(@"^(010|012|011|015)\d{8}$", ErrorMessage = "A phone number must start with 010, 011, 012 ,015")]
        public string Phone { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please enter the employee birth date")]
        public string DateOfBirth { get; set; } = string.Empty;

        
        
    }
}
