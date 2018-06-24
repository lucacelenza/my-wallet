using System.ComponentModel.DataAnnotations;

namespace CLSoft.MyWallet.Models.Auth
{
    public class ChangePasswordViewModel
    {
        [Required, MaxLength(20)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string Password { get; set; }

        [Required, MaxLength(20), Compare("Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Repeat password")]
        public string RepeatPassword { get; set; }
    }
}