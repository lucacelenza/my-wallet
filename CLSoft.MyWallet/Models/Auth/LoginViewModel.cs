using System.ComponentModel.DataAnnotations;

namespace CLSoft.MyWallet.Models.Auth
{
    public class LoginViewModel
    {
        [Required, MaxLength(100)]
        [Display(Name = "Email")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required, MaxLength(20)]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememeberMe { get; set; }
    }
}