using System;
using System.Collections.Generic;
using System.Linq;
using CLSoft.MyWallet.Data.Models.Transactions;

namespace CLSoft.MyWallet.Business.TimeBalance.Models
{
    public class LastQuarterTimeBalanceSearchRange : TimeBalanceSearchRange
    {
        public override DateTime From => To.AddMonths(-3);

        internal override IDictionary<string, decimal> GetTimeBalance(IEnumerable<Transaction> transactions)
        {
            return transactions
                .GroupBy(t => new { t.RegisteredOn.Month, t.RegisteredOn.Year })
                .Select(g => new KeyValuePair<string, decimal>(new DateTime(g.Key.Year, g.Key.Month, 1).ToString("MMM"), g.Sum(t => t.Amount)))
                .ToDictionary(k => k.Key, v => v.Value);
        }
    }
}