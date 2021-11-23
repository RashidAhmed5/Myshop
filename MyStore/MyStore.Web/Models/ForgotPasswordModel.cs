using System.ComponentModel.DataAnnotations;

namespace MyShop.Web.Models
{
    public class ForgotPasswordModel
    {
        [Display(Name = "User Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "User Email Id Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
    }
}
