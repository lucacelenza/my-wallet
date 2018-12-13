using System;
using System.Collections.Generic;
using CLSoft.MyWallet.Business.Time;
using CLSoft.MyWallet.Data.Models.Transactions;

namespace CLSoft.MyWallet.Business.TimeBalance.Models
{
    public abstract class TimeBalanceSearchRange
    {
        public abstract DateTime From { get; }
        public virtual DateTime To { get; }

        protected TimeBalanceSearchRange()
        {
            To = TimeProvider.Current.Now;
        }

        internal abstract IDictionary<string, decimal> GetTimeBalance(decimal startFromBalance, IEnumerable<Transaction> transactions);
    }
}