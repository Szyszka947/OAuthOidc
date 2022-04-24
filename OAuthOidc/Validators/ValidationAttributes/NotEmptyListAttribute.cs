using System.ComponentModel.DataAnnotations;

namespace OAuthOidc.Validators.ValidationAttributes
{
    public class NotEmptyListAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || (value as List<object>).Count == 0)
                return new ValidationResult(string.Empty);

            return ValidationResult.Success;
        }
    }
}
