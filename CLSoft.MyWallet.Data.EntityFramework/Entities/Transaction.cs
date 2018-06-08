using System;

namespace CLSoft.MyWallet.Data.EntityFramework.Entities
{
    public class Transaction
    {
        public long Id { get; set; }
        public long WalletId { get; set; }
        public Wallet Wallet { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime RegisteredOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}