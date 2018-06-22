using System.ComponentModel.DataAnnotations;

namespace CLSoft.MyWallet.Models.Auth
{
    public class RegisterUserViewModel
    {
        [Required, MaxLength(100)]
        [Display(Name = "Email address")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required, MaxLength(20)]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, MaxLength(100)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required, MaxLength(100)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
    }
}