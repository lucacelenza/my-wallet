﻿using System;

namespace CLSoft.MyWallet.Data.Models.Transactions
{
    public class Transaction
    {
        public long Id { get; set; }
        public long WalletId { get; set; }
        public string WalletName { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime RegisteredOn { get; set; }
    }
}