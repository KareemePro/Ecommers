


namespace LoginAndRegster.ViewModel
{
    public class CreateEmployeeViewModel
    {
        [Required(ErrorMessage = "Please enter your first name")]
        [MinLength(3, ErrorMessage = "A name must be at least 3 letters")]
        [MaxLength(15, ErrorMessage = "A name must be not more than 15 letters")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please enter your first name in English letters")]
        [Display(Name = "First name")]
        public string FirstName { get; set; } = string.Empty;


        [Required(ErrorMessage = "Please enter the employee middle name")]
        [MinLength(3, ErrorMessage = "A name must be at least 3 letters")]
        [MaxLength(15, ErrorMessage = "A name must be not more than 15 letters")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please enter your first name in English letters")]
        [Display(Name ="Middle name")]
        public string MiddleName { get; set; } = string.Empty;



        [Required(ErrorMessage = "Please enter your last name")]
        [MinLength(3, ErrorMessage = "A name must be at least 3 letters")]
        [MaxLength(15, ErrorMessage = "A name must be not more than 15 letters")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please enter your last name in English letters")]
        [Display(Name = "Last name")]
        public string LastName { get; set; } = string.Empty;





        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [RegularExpression(@"\b\S+@(Admin|SuperAdmin)", ErrorMessage = "At the moment we only accept Admin or SuperAdmin")]
        public string Email { get; set; } = string.Empty;




        [Required(ErrorMessage = "Please enter the employee birth date")]
        [DataType(DataType.Date)]
        public string DateOfBirth { get; set; } = string.Empty;



        [Required(ErrorMessage = "Please enter your phone number")]
        [MinLength(11, ErrorMessage = "A phone number should contain 11 digits")]
        [MaxLength(11, ErrorMessage = "A phone number should contain 11 digits")]
        [RegularExpression(@"^(010|012|011|015)\d{8}$", ErrorMessage = "A phone number must start with 010, 011, 012 ,015")]
        public string Phone { get; set; } = string.Empty;




        [Required(ErrorMessage = "Please enter a password")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$",
         ErrorMessage = "Password must be at least 6 characters long and contain at least 1 letter, 1 number")]
        public string Password { get; set; } = string.Empty;





        [Required(ErrorMessage ="Please enter a role of employee")]
        public int RoleId { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; } = Enumerable.Empty<SelectListItem>();



        [Required(ErrorMessage = "Please enter a confirm password")]
        [Compare("Password", ErrorMessage = "Password not mutched")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; } = string.Empty;

       

    }
}

