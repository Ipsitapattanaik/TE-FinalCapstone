using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Capstone.Web.Models
{
    public class UserProfile
    {
        [Required(ErrorMessage = "* Required Field")]
        [EmailAddress(ErrorMessage = "* Input is not a valid email address")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "* Required Field")]
        [EmailAddress(ErrorMessage = "* Input is not a valid email address")]
        [Compare("UserEmail", ErrorMessage = "* Input does not match Email field")]
        public string ConfirmEmail { get; set; }

        [Required(ErrorMessage = "* Required Field")]
        [MinLength(8, ErrorMessage = "* Password must be at least 8 characters")]
        public string UserPassword { get; set; }

        [Required(ErrorMessage = "* Required Field")]
        [Compare("UserPassword", ErrorMessage = "* Input does not match Password field")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "* Required Field")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "* Required Field")]
        public string LastName { get; set; }

       // [DataType(DataType.PhoneNumber)]
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        public string Role { get; set; } = "user";

        public string Salt { get; set; } //this is a placeholder
                                         //  public int 

    }
}
