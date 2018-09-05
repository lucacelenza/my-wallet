using System;
using System.Collections.Generic;
using System.Linq;
using CLSoft.MyWallet.Data.Models.Transactions;

namespace CLSoft.MyWallet.Business.TimeBalance.Models
{
    public class LastQuarterTimeBalanceSearchRange : TimeBalanceSearchRange
    {
        public override DateTime From => To.AddMonths(-3);

        internal override IDictionary<string, decimal> GetTimeBalance(decimal startFromBalance, IEnumerable<Transaction> transactions)
        {
            var months = GetMonths();

            var result = new Dictionary<string, decimal>();
            var balance = startFromBalance;

            foreach (var month in months)
            {
                balance += transactions
                    .Where(t => t.RegisteredOn.ToString("MMM").Equals(month))
                    .Select(t => t.Amount)
                    .Sum();

                result.Add(month, balance);
            }

            return result;
        }

        internal IEnumerable<string> GetMonths()
        {
            for (var i = 0; i < 3; i++)
                yield return From.AddMonths(i).ToString("MMM");
        }
    }
}