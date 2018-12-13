using System;
using System.Collections.Generic;
using System.Linq;
using CLSoft.MyWallet.Data.Models.Transactions;

namespace CLSoft.MyWallet.Business.TimeBalance.Models
{
    public class LastWeekTimeBalanceSearchRange : TimeBalanceSearchRange
    {
        public override DateTime From => To.AddDays(-7);

        internal override IDictionary<string, decimal> GetTimeBalance(decimal startFromBalance, IEnumerable<Transaction> transactions)
        {
            var days = GetDays();

            var result = new Dictionary<string, decimal>();
            var balance = startFromBalance;

            foreach (var day in days)
            {
                balance += transactions
                    .Where(t => t.RegisteredOn.ToString("ddd").Equals(day))
                    .Select(t => t.Amount)
                    .Sum();

                result.Add(day, balance);
            }

            return result;
        }

        private IEnumerable<string> GetDays()
        {
            for (var i = 0; i < 7; i++)
                yield return From.AddDays(i).ToString("ddd");
        }
    }
}