using System.ComponentModel.DataAnnotations;

namespace Register9.ViewModels
{
    public class RegisterVM
    {

        [Display(Name = "Name *")]
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")] // Dit zet de minimum length op 3 en max op 50 karakters
        public string Name { get; set; }

        [Display(Name = "First Name *")]
        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }

        [Display(Name = "Email *")]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [Display(Name = "Zip Code *")]
        [Required(ErrorMessage = "Zip Code is required.")]
        [Range(1000, 9999, ErrorMessage = "Zip Code must be between 1000 and 9999.")]
        public int ZipCode { get; set; }

        [Display(Name = "Age *")]
        [Required(ErrorMessage = "Age is required.")]
        public int Age { get; set; }

        [Display(Name = "Mobile Phone *")]
        [Required(ErrorMessage = "Mobile Phone is required.")]
        [RegularExpression(@"^(?:0032486/\d{6}|\+\s32486/\d{6})$", ErrorMessage = "Mobile phone must be in the format 0032486/123456 or + 32486/123456.")]
        public string MobilePhone { get; set; }
    }
}