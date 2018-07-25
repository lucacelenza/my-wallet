using System;

namespace CLSoft.MyWallet.Data.Models.Wallets
{
    public class AddWalletRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long UserId { get; set; }
        public DateTime RegisteredOn { get; set; }
        public Transaction BaseTransaction { get; set; }

        public class Transaction
        {
            public string Description { get; set; }
            public decimal Amount { get; set; }
        }
    }
}