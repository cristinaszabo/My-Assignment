using System;
using System.ComponentModel.DataAnnotations;

namespace DojoActivity.Models {
    public class LoginUser {

        // No other fields!
        [Required(ErrorMessage="Email is Required!")]
        [EmailAddress]
        public string LoginEmail { get; set; }

        [Required(ErrorMessage="Password is Required!")]
        [DataType(DataType.Password)]
        [MinLength (8, ErrorMessage = "Password must be 8 characters or longer!")]
        public string LoginPassword { get; set; }
    }
}