using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AngularBackEnd.Filters
{
    public class PatternFilterAttribute : ValidationAttribute
    {
        public string GetErrorMessage() => "Ticket number pattern invalid.";

        public PatternFilterAttribute() { }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (Regex.Match((string)value, "[a-zA-Z0-9]{13}").Success) return ValidationResult.Success;
            return new ValidationResult(GetErrorMessage());
        }
    }
}
