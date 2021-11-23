using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Web.Models
{
    public class LoginModel
    {
        [Display(Name = "User Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "User Email Id Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
