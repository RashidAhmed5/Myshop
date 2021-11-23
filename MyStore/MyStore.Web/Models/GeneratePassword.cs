using System.ComponentModel.DataAnnotations;


namespace MyShop.Web.Models
{
    public class GeneratePassword
    {
        public long Id { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
