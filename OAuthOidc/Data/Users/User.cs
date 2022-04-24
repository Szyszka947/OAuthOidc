using System.ComponentModel.DataAnnotations;

namespace OAuthOidc.Data.Users
{
    public class User
    {
        public int Id { get; set; }

        [EmailAddress(ErrorMessage = "E-mail is wrong")]
        [MaxLength(255, ErrorMessage = "E-mail is too long")]
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public List<UserClaim> Claims { get; set; }
    }
}
