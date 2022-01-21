using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FreeCourse.Web.Models
{
    public class SigninInput
    {
        [Display(Name ="Your email address")]
        public string Email { get; set; }
        [Display(Name = "Your password")]
        public string Password { get; set; }
        [Display(Name = "remember me")]
        public bool IsRemember { get; set; }
    }
}
