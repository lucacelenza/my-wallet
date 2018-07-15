using System.ComponentModel.DataAnnotations;

namespace CLSoft.MyWallet.Models.Wallets
{
    public class WalletViewModel
    {
        [Required, MaxLength(50)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [MaxLength(100)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public CurrencyViewModel Amount { get; set; }

        public WalletViewModel()
        {
            Amount = new CurrencyViewModel();
        }
    }
}