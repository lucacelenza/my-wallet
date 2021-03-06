﻿using System;
using System.Collections.Generic;

namespace CLSoft.MyWallet.Data.EntityFramework.Entities
{
    public class Wallet
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime RegisteredOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}