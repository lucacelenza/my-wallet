using System;

namespace CLSoft.MyWallet.Data.Models.Wallets
{
    public class EditWalletRequest
    {
        public long WalletId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime UpdatedOn { get; set; }
        public decimal BaseTransactionAmount { get; set; }
    }
}