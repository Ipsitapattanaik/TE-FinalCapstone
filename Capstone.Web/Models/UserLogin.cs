using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class UserLogin
    {
        [Required]
        [EmailAddress(ErrorMessage ="This isn't an Email")]
        [Display(Name = "Email")]
        public string UserEmail { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string UserPassword { get; set; }
    }
}