using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DojoActivity.Models {
    public class User {
        [Key]
        public int UserId { get; set; }

        [Required (ErrorMessage = "First Name is Required!")]
        [MinLength (3, ErrorMessage = "First Name must be 3 characters or longer!")]
        public string FirstName { get; set; }

        [Required (ErrorMessage = "Last Name is Required!")]
        [MinLength (3, ErrorMessage = "Last Name must be 3 characters or longer!")]
        public string LastName { get; set; }

        [Required (ErrorMessage = "Email is Required!")]
        [EmailAddress]
        public string Email { get; set; }

        [Required (ErrorMessage = "Password is Required!")]
        [DataType (DataType.Password)]
        [MinLength (8, ErrorMessage = "Password must be 8 characters or longer!")]
        [PasswordCheck (ErrorMessage = "Your password must contain at least 1 number, 1 letter and a special character!")]
        public string Password { get; set; }

        // Will not be mapped to your users table!
        [NotMapped]
        [Compare ("Password")]
        [DataType (DataType.Password)]
        public string Confirm { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public List<Activity> CreatedActivities { get; set; }
        public List<Participation> Participations { get; set; }
    }
}