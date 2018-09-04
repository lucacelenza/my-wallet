using System;
using System.Collections.Generic;
using System.Linq;
using CLSoft.MyWallet.Data.Models.Transactions;

namespace CLSoft.MyWallet.Business.TimeBalance.Models
{
    public class LastWeekTimeBalanceSearchRange : TimeBalanceSearchRange
    {
        public override DateTime From => To.AddDays(-7);

        internal override IDictionary<string, decimal> GetTimeBalance(IEnumerable<Transaction> transactions)
        {
            return transactions
                .GroupBy(t => new { t.RegisteredOn.Day, t.RegisteredOn.Month, t.RegisteredOn.Year })
                .Select(g => new KeyValuePair<string, decimal>(new DateTime(g.Key.Year, g.Key.Month, g.Key.Day).ToString("ddd"), g.Sum(t => t.Amount)))
                .ToDictionary(k => k.Key, v => v.Value);
        }
    }
}