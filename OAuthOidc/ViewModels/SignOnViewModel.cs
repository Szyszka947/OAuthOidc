using System.ComponentModel.DataAnnotations;

namespace OAuthOidc.ViewModels
{
    public class SignOnViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Invalid e-mail address syntax or e-mail is taken")]
        [EmailAddress(ErrorMessage = "Invalid e-mail address syntax or e-mail is taken")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "Password must contain at least 8 characters, one uppercase, one lowercase, one number and one special character")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Repat password is required")]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        public string RepeatPassword { get; set; }
    }
}
