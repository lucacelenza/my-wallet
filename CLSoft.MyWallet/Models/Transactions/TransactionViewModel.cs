using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CLSoft.MyWallet.Models.Transactions
{
    public class TransactionViewModel
    {
        [Required]
        [Display(Name = "Wallet")]
        public long SelectedWalletId { get; set; }
        public SelectList Wallets { get; set; }

        public TransactionType Type { get; set; }

        public CurrencyViewModel Amount { get; set; }

        [Required, MaxLength(100)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public TransactionViewModel()
        {
            Amount = new CurrencyViewModel();
        }
    }
}