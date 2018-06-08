using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CLSoft.MyWallet.Models.Transactions
{
    public class TransactionViewModel
    {
        [Required]
        public long SelectedWalletId { get; set; }
        public SelectList Wallets { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}