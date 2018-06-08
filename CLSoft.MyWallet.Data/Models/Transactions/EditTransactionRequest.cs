using System;

namespace CLSoft.MyWallet.Data.Models.Transactions
{
    public class EditTransactionRequest
    {
        public long TransactionId { get; set; }
        public long WalletId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}