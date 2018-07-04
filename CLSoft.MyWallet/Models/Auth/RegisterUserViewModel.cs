using System.ComponentModel.DataAnnotations;

namespace CLSoft.MyWallet.Models.Auth
{
    public class RegisterUserViewModel
    {
        [Required, MaxLength(100)]
        [Display(Name = "Email")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required, MaxLength(20)]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, MaxLength(20), Compare("Password")]
        [Display(Name = "Repeat password")]
        [DataType(DataType.Password)]
        public string RepeatPassword { get; set; }

        [Required, MaxLength(100)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required, MaxLength(100)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        public StartWalletViewModel StartWallet { get; set; }

        public class StartWalletViewModel
        {
            [Required, MaxLength(50)]
            [Display(Name = "Name")]
            public string Name { get; set; }

            [MaxLength(100)]
            [Display(Name = "Description")]
            public string Description { get; set; }

            [Required]
            [Display(Name = "Amount")]
            [DataType(DataType.Currency)]
            public decimal Amount { get; set; }
        }
    }
}