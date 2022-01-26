using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FreeCourse.Web.Models
{
    public class SigninInput
    {
        [Required]
        [Display(Name ="Your email address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Your password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "remember me")]
        public bool IsRemember { get; set; }
    }
}
