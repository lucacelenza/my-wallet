using System;
using System.Collections.Generic;
using System.Linq;
using CLSoft.MyWallet.Data.Models.Transactions;

namespace CLSoft.MyWallet.Business.TimeBalance.Models
{
    public class LastMonthTimeBalanceSearchRange : TimeBalanceSearchRange
    {
        public override DateTime From => To.AddMonths(-1);

        internal override IDictionary<string, decimal> GetTimeBalance(IEnumerable<Transaction> transactions)
        {
            return transactions
                .GroupBy(t => GetWeek(t.RegisteredOn, DayOfWeek.Monday))
                .Select(g => new KeyValuePair<string, decimal>(g.Key, g.Sum(t => t.Amount)))
                .ToDictionary(k => k.Key, v => v.Value);
        }

        public static string GetWeek(DateTime dateTime, DayOfWeek startOfWeek)
        {
            var weekStart = dateTime.AddDays(-(int)dateTime.DayOfWeek + (int)startOfWeek).Date;
            var weekEnd = weekStart.AddDays(7).AddSeconds(-1);

            return $"{weekStart.ToString("dd/MM")} - {weekEnd.ToString("dd/MM")}";
        }
    }
}