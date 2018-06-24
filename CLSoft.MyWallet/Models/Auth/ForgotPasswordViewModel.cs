using System.ComponentModel.DataAnnotations;

namespace CLSoft.MyWallet.Models.Auth
{
    public class ForgotPasswordViewModel
    {
        [Required, MaxLength(100)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }
    }
}