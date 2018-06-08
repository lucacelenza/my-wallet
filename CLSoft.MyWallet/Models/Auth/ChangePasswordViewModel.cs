using System.ComponentModel.DataAnnotations;

namespace CLSoft.MyWallet.Models.Auth
{
    public class ChangePasswordViewModel
    {
        [Required]
        public string Password { get; set; }

        [Required]
        public string RepeatPassword { get; set; }
    }
}