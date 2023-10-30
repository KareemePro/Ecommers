namespace LoginAndRegster.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        [EmailAddress]  
        public string Email { get; set; } = string.Empty;


        [Required(ErrorMessage = "Please enter your phone number")]
        [MinLength(11, ErrorMessage = "A phone number should contain 11 digits")]
        [MaxLength(11, ErrorMessage = "A phone number should contain 11 digits")]
        [RegularExpression(@"^(010|012|011|015)\d{8}$", ErrorMessage = "A phone number must start with 010, 011, 012 ,015")]
        public string PhoneNumber { get; set; } = string.Empty;


        [Required(ErrorMessage="Enter Your Message")]
        [MaxLength(200, ErrorMessage = "A message must be not more than 200 letters")]
        [MinLength(20, ErrorMessage = "A message must be at least  20 letters")]
        public string Message { get; set; } = string.Empty;

    }
}
