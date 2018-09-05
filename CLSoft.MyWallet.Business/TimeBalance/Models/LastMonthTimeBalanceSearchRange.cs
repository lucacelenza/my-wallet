using System;
using System.Collections.Generic;
using System.Linq;
using CLSoft.MyWallet.Data.Models.Transactions;

namespace CLSoft.MyWallet.Business.TimeBalance.Models
{
    public class LastMonthTimeBalanceSearchRange : TimeBalanceSearchRange
    {
        public override DateTime From => To.AddMonths(-1);

        internal override IDictionary<string, decimal> GetTimeBalance(decimal startFromBalance, IEnumerable<Transaction> transactions)
        {
            var weeks = GetWeeks();

            var result = new Dictionary<string, decimal>();
            var balance = startFromBalance;

            foreach (var week in weeks)
            {
                balance += transactions
                    .Where(t => week.From <= t.RegisteredOn && t.RegisteredOn <= week.To)
                    .Select(t => t.Amount)
                    .Sum();

                result.Add($"{week.From.ToString("dd/MM")} - {week.To.ToString("dd/MM")}", balance);
            }

            return result;
        }

        internal IEnumerable<DateRange> GetWeeks()
        {
            var from = From;

            while (from < To)
            {
                var to = from.AddDays(7);

                if (to > To) to = To;

                yield return new DateRange(from, to);

                from = to;
            }
        }

        internal class DateRange
        {
            public DateTime From { get; }
            public DateTime To { get; }

            public DateRange(DateTime from, DateTime to)
            {
                From = from;
                To = to;
            }
        }
    }
}