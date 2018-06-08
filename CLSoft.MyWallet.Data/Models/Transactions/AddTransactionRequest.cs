using System;

namespace CLSoft.MyWallet.Data.Models.Transactions
{
    public class AddTransactionRequest
    {
        public long WalletId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime RegisteredOn { get; set; }
    }
}