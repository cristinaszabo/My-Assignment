using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DojoActivity.Models {

    public class PasswordCheckAttribute : ValidationAttribute {
        protected override ValidationResult IsValid (object value, ValidationContext validationContext) {
            string valStr = Convert.ToString (value);
            string regex = @"(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z])";
            var match = Regex.Match (valStr, regex, RegexOptions.IgnoreCase);
            if (match.Success) {
                return ValidationResult.Success;
            } else {
                return new ValidationResult (ErrorMessage);
            }
        }
    }
}