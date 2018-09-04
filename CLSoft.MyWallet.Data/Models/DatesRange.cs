using System;

namespace CLSoft.MyWallet.Data.Models
{
    public class DatesRange
    {
        public DateTime From { get; }
        public DateTime To { get; }

        public DatesRange(DateTime from, DateTime to)
        {
            From = from;
            To = to;
        }
    }
}